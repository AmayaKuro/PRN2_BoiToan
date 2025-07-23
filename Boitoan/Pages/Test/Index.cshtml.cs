using Boitoan.DAL.Entities;
using Boitoan.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using SPTS_Writer.Services.Abstraction;

namespace SPTS_Writer.Pages.Test
{
    public class IndexModel : PageModel
    {
        private readonly ITestService _testService;
        private const int QuestionsPerPage = 5;

        public IndexModel(ITestService testService)
        {
            _testService = testService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty]
        public TestPageModel ViewModel { get; set; } = new();

        public int TotalPages { get; set; }

        public List<Question> CurrentPageQuestions { get; set; } = new();

        public Dictionary<int, string> AnswerMap { get; set; } = new();

        public async Task<IActionResult> OnGetAsync([FromQuery] string id)
        {
            var test = await _testService.GetTestByIdAsync(id);
            if (test == null) return NotFound();

            // Load answers from TempData
            AnswerMap = TempData.ContainsKey("answers")
                ? JsonConvert.DeserializeObject<Dictionary<int, string>>(TempData["answers"]!.ToString()) ?? new Dictionary<int, string>()
                : new Dictionary<int, string>();
            
            // Check if this is a different test and clear answers if so
            string currentTestId = TempData.ContainsKey("currentTestId") ? TempData["currentTestId"]?.ToString() : null;
            if (currentTestId != id)
            {
                AnswerMap = new Dictionary<int, string>();
                TempData["currentTestId"] = id;
            }
            
            // Filter answers to only include questions from current test
            var currentTestQuestionIds = test.Questions.Select(q => q.Id).ToHashSet();
            AnswerMap = AnswerMap.Where(x => currentTestQuestionIds.Contains(x.Key)).ToDictionary(x => x.Key, x => x.Value);
            
            // Keep answers in TempData for next request
            TempData["answers"] = JsonConvert.SerializeObject(AnswerMap);
            TempData.Keep("answers");
            TempData.Keep("currentTestId");

            int totalQuestions = test.Questions.Count;
            TotalPages = (int)Math.Ceiling(totalQuestions / (double)QuestionsPerPage);

            int startIndex = (CurrentPage - 1) * QuestionsPerPage;
            CurrentPageQuestions = test.Questions.Skip(startIndex).Take(QuestionsPerPage).ToList();

            ViewModel = new TestPageModel
            {
                Test = test,
                CurrentPage = CurrentPage,
                TotalPages = TotalPages,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id, int currentPage)
        {
            // Load existing answers from TempData
            var answers = TempData.ContainsKey("answers")
                ? JsonConvert.DeserializeObject<Dictionary<int, string>>(TempData["answers"]!.ToString()) ?? new Dictionary<int, string>()
                : new Dictionary<int, string>();

            // Process form data - convert all values to strings
            foreach (var entry in Request.Form)
            {
                if (entry.Key.StartsWith("question_") &&
                    int.TryParse(entry.Key.Replace("question_", ""), out var questionId))
                {
                    // Ensure we're storing as string
                    answers[questionId] = entry.Value.ToString();
                }
            }

            // Save answers back to TempData
            TempData["answers"] = JsonConvert.SerializeObject(answers);
            TempData.Keep("answers");

            var test = await _testService.GetTestByIdAsync(id);
            if (test == null) return NotFound();

            int totalPages = (int)Math.Ceiling(test.Questions.Count / (double)QuestionsPerPage);
            int nextPage = currentPage + 1;
            
            
            return nextPage > totalPages
                ? RedirectToPage("/Test/Complete")
                : RedirectToPage("/Test/Index", new { id = id, currentPage = nextPage });
        }
    }
}