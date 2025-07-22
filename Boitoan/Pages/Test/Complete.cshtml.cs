using Boitoan;
using Boitoan.BLL;
using Boitoan.DAL.Entities;
using Boitoan.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SPTS_Writer.Services;
using System.Security.Claims;

namespace SPTS_Writer.Pages.Test
{
    public class CompleteModel : PageModel
    {
        private readonly TestHistoryService _testHistoryService;
        private readonly TestService _testService;
        private readonly UserService _userService;
        private readonly MongoDbContext _context;
        private readonly IHubContext<SignalRHub> _hubContext;

        public CompleteModel(TestHistoryService testHistoryService, UserService userService, MongoDbContext context, IHubContext<SignalRHub> hubContext, TestService testService)
        {
            _testHistoryService = testHistoryService;
            _userService = userService;
            _context = context;
            _hubContext = hubContext;
            _testService = testService;
        }

        public string ResultTitle { get; set; } = string.Empty;
        public string ResultType { get; set; } = string.Empty; // "MBTI" or "DISC"
        public string ResultCode { get; set; } = string.Empty;
        public string ResultDescription { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!TempData.ContainsKey("answers"))
                return RedirectToPage("/Test/Index");

            var answers = JsonConvert.DeserializeObject<Dictionary<int, string>>(TempData["answers"]!.ToString());
            if (answers == null || answers.Count == 0)
                return RedirectToPage("/Test/Index");

            var answerCounts = answers.Values
                .GroupBy(v => v)
                .ToDictionary(g => g.Key, g => g.Count());

            // MBTI logic
            var mbtiLetters = new[] { "E", "I", "S", "N", "T", "F", "J", "P" };
            bool isMbti = answerCounts.Keys.Any(k => mbtiLetters.Contains(k));

            // DISC logic
            var discTypes = new[] { "Dominance", "Influence", "Steadiness", "Conscientiousness" };
            bool isDisc = answerCounts.Keys.Any(k => discTypes.Contains(k));

            if (isMbti)
            {
                var mbtiCounts = mbtiLetters.ToDictionary(letter => letter, letter => answerCounts.GetValueOrDefault(letter, 0));
                ResultCode = string.Concat(
                    mbtiCounts["E"] >= mbtiCounts["I"] ? "E" : "I",
                    mbtiCounts["S"] >= mbtiCounts["N"] ? "S" : "N",
                    mbtiCounts["T"] >= mbtiCounts["F"] ? "T" : "F",
                    mbtiCounts["J"] >= mbtiCounts["P"] ? "J" : "P"
                );
                ResultDescription = MbtiHelper.GetDescription(ResultCode);
                ResultType = "MBTI";
                ResultTitle = " Kết quả MBTI của bạn là:";
            }
            else if (isDisc)
            {
                var discCounts = discTypes.ToDictionary(t => t, t => answerCounts.GetValueOrDefault(t, 0));
                ResultCode = discCounts.OrderByDescending(x => x.Value).First().Key;
                ResultDescription = DiscHelper.GetDescription(ResultCode);
                ResultType = "DISC";
                ResultTitle = " Kết quả DISC của bạn là:";
            }
            else
            {
                ResultTitle = "Không thể xác định kết quả";
                ResultDescription = "Vui lòng làm lại bài kiểm tra.";
                ResultCode = "N/A";
            }

            // Save to DB
            string userId = User.FindFirst(ClaimTypes.Sid)?.Value
                ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? string.Empty;

            var testId = TempData.ContainsKey("currentTestId") ? TempData["currentTestId"]?.ToString() : string.Empty;

            var answerList = answers.Select(a => new Answer
            {
                QuestionId = a.Key,
                Value = a.Value
            }).ToList();

            var history = _testHistoryService.SaveTestResult(
                userId,
                testId,
                ResultCode,
                TestStatus.Completed,
                answerList
            );

            var user = await _userService.GetUserByIdAsync(history.UserId.ToString());
            var test = await _testService.GetTestByIdAsync(history.TestId.ToString());

            // Count each answer value
            var answerCounting = history.Answer?
                .GroupBy(a => a.Value)
                .ToDictionary(g => g.Key, g => g.Count()) ?? new Dictionary<string, int>();

            var HistoryDisplayDto = new HistoryDisplayDto
            {
                TestName = test?.Method.ToString() ?? "Unknown",
                UserName = user?.Name ?? "Unknown",
                Result = history.Result,
                AnswerCounts = answerCounting,
                CreatedAt = history.CreatedAt
            };

            await _hubContext.Clients.All.SendAsync("ReloadList", HistoryDisplayDto);

            TempData.Clear();
            return Page();
        }
    }
}
