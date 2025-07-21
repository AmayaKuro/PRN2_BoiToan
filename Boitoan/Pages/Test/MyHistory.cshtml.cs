using Boitoan.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services;
using System.Security.Claims;

namespace SPTS_Writer.Pages.Test
{
    public class MyHistoryModel : PageModel
    {
        private readonly TestHistoryService _historyService;
        private readonly TestService _testService;
        private readonly HistoryService _historyServices;

        public MyHistoryModel(TestHistoryService historyService, TestService testService, HistoryService historyServices)
        {
            _historyService = historyService;
            _testService = testService;
            _historyServices = historyServices;
        }

        public List<TestHistoryDto> TestHistories { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            string userId = User.FindFirst(ClaimTypes.Sid)?.Value
                ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? string.Empty;

            if (string.IsNullOrEmpty(userId))
                return RedirectToPage("/Account/LoginRegister");

            var allHistories = await _historyServices.GetHistoriesByUserIdAsync(userId);

            foreach (var history in allHistories.OrderByDescending(h => h.CreatedAt))
            {
                var test = await _testService.GetTestByIdAsync(history.TestId.ToString());

                TestHistories.Add(new TestHistoryDto
                {
                    TestName = test?.Method.ToString() ?? "Unknown",
                    Result = history.Result,
                    CreatedAt = history.CreatedAt,
                    Answer = history.Answer ?? new List<Answer>() // ? map Answer here
                });
            }

            return Page();
        }

        public async Task<JsonResult> OnGetUserHistoryChartAsync()
        {
            string userId = User.FindFirst(ClaimTypes.Sid)?.Value
                ?? User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? string.Empty;

            var allHistories = (await _historyServices.GetHistoriesByUserIdAsync(userId)).ToList();

            var months = Enumerable.Range(0, 6)
                .Select(i => DateTime.UtcNow.AddMonths(-i))
                .Select(d => new DateTime(d.Year, d.Month, 1))
                .OrderBy(d => d)
                .ToList();

            var labels = months.Select(m => m.ToString("yyyy-MM")).ToList();
            var historyCounts = months.Select(m => allHistories.Count(h => h.CreatedAt.Year == m.Year && h.CreatedAt.Month == m.Month)).ToList();

            return new JsonResult(new { labels, historyCounts });
        }

        public class TestHistoryDto
        {
            public string TestName { get; set; }
            public string Result { get; set; }
            public DateTime CreatedAt { get; set; }

            // ? Add this to fix the Answer-related error in the view
            public List<Answer> Answer { get; set; } = new();
        }
    }
}
