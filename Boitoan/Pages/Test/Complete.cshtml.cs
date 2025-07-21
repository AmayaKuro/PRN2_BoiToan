using Boitoan;
using Boitoan.BLL;
using Boitoan.DAL.Entities;
using Boitoan.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System.Security.Claims;

namespace SPTS_Writer.Pages.Test
{
    public class CompleteModel : PageModel
    {
        private readonly TestHistoryService _testHistoryService;
        private readonly UserService _userService;
        private readonly MongoDbContext _context;
        private readonly IHubContext<SignalRHub> _hubContext;

        public CompleteModel(TestHistoryService testHistoryService, UserService userService, MongoDbContext context, IHubContext<SignalRHub> hubContext)
        {
            _testHistoryService = testHistoryService;
            _userService = userService;
            _context = context;
            _hubContext = hubContext;
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
                ResultTitle = " K?t qu? MBTI c?a b?n l�:";
            }
            else if (isDisc)
            {
                var discCounts = discTypes.ToDictionary(t => t, t => answerCounts.GetValueOrDefault(t, 0));
                ResultCode = discCounts.OrderByDescending(x => x.Value).First().Key;
                ResultDescription = DiscHelper.GetDescription(ResultCode);
                ResultType = "DISC";
                ResultTitle = " K?t qu? DISC c?a b?n l�:";
            }
            else
            {
                ResultTitle = "Kh�ng th? x�c ??nh k?t qu?.";
                ResultDescription = "Vui l�ng l�m l?i b�i ki?m tra.";
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

            await _hubContext.Clients.All.SendAsync("ReloadList", history);

            TempData.Clear();
            return Page();
        }
    }
}
