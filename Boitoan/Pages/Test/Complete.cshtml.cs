using Boitoan;
using Boitoan.BLL;
using Boitoan.DAL.Entities;
using Boitoan.Hubs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Security.Claims;
using static System.Net.Mime.MediaTypeNames;

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
        public string MbtiResult { get; set; } = string.Empty;
        public string MbtiDescription { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!TempData.ContainsKey("answers"))
                return RedirectToPage("/Test/Index");

            var answers = JsonConvert.DeserializeObject<Dictionary<int, string>>(TempData["answers"]!.ToString());
            if (answers == null || answers.Count == 0)
                return RedirectToPage("/Test/Index");

            // Count MBTI letters
            var mbtiCounts = new Dictionary<string, int>
            {
                ["E"] = 0,
                ["I"] = 0,
                ["S"] = 0,
                ["N"] = 0,
                ["T"] = 0,
                ["F"] = 0,
                ["J"] = 0,
                ["P"] = 0
            };

            foreach (var val in answers.Values)
            {
                if (mbtiCounts.ContainsKey(val))
                    mbtiCounts[val]++;
            }

            MbtiResult =
                (mbtiCounts["E"] >= mbtiCounts["I"] ? "E" : "I") +
                (mbtiCounts["S"] >= mbtiCounts["N"] ? "S" : "N") +
                (mbtiCounts["T"] >= mbtiCounts["F"] ? "T" : "F") +
                (mbtiCounts["J"] >= mbtiCounts["P"] ? "J" : "P");

            // Get userId from claims and parse to Guid
            string userId = User.FindFirst(ClaimTypes.Sid)?.Value
              ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value
              ?? string.Empty;

            var user = await _userService.GetUserByIdAsync(userId);

            // Get testId from TempData as string
            string testId = TempData.ContainsKey("currentTestId") ? TempData["currentTestId"]?.ToString() : string.Empty;

            var answerList = answers.Select(a => new Answer { QuestionId = a.Key, Value = a.Value }).ToList();

            var history = _testHistoryService.SaveTestResult(
                userId,    // string
                testId,    // string
                MbtiResult,
                TestStatus.Completed,
                answerList
            );
            await _hubContext.Clients.All.SendAsync("ReloadList", history);

            var latest = _context.Histories.Find(_ => true).SortByDescending(h => h.CreatedAt).FirstOrDefault();
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(latest, Formatting.Indented));

            MbtiDescription = MbtiHelper.GetDescription(MbtiResult);

            TempData.Clear(); // Optional: clear after finishing

            return Page();
        }
    }
}
