using Boitoan.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services;

public class EditTestModel : PageModel
{
    private readonly TestService _testService;
    [BindProperty]
    public Test Test { get; set; }

    public EditTestModel(TestService testService)
    {
        _testService = testService;
    }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        Test = await _testService.GetTestByIdAsync(id);
        if (Test == null) return NotFound();
        if (Test.Questions == null) Test.Questions = new List<Question>();
        foreach (var q in Test.Questions)
            if (q.Options == null) q.Options = new List<Option>();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(string addQuestion, int? removeQuestion, string addOption, string removeOption)
    {
        // Remove submit buttons
        ModelState.Remove("addQuestion");
        ModelState.Remove("addOption");
        ModelState.Remove("removeOption");

        // Ensure lists are not null
        if (Test.Questions == null) Test.Questions = new List<Question>();
        foreach (var q in Test.Questions)
            if (q.Options == null) q.Options = new List<Option>();

        // Add Question
        if (addQuestion != null)
        {
            int nextId = Test.Questions.Count > 0 ? Test.Questions.Max(q => q.Id) + 1 : 1;
            Test.Questions.Add(new Question { Id = nextId, Type = Test.Method, Options = new List<Option>() });
            return Page();
        }

        // Remove Question
        if (removeQuestion.HasValue)
        {
            if (removeQuestion.Value >= 0 && removeQuestion.Value < Test.Questions.Count)
                Test.Questions.RemoveAt(removeQuestion.Value);
            return Page();
        }

        // Add Option
        if (!string.IsNullOrEmpty(addOption) && int.TryParse(addOption, out int qIdx) && qIdx >= 0 && qIdx < Test.Questions.Count)
        {
            var options = Test.Questions[qIdx].Options;
            options.Add(new Option { Detail = "", Value = AllAnswer.E });
            return Page();
        }

        // Remove Option
        if (!string.IsNullOrEmpty(removeOption))
        {
            var parts = removeOption.Split('-');
            if (parts.Length == 2 && int.TryParse(parts[0], out int qIdx2) && int.TryParse(parts[1], out int oIdx))
            {
                if (qIdx2 >= 0 && qIdx2 < Test.Questions.Count)
                {
                    var options = Test.Questions[qIdx2].Options;
                    if (oIdx >= 0 && oIdx < options.Count)
                        options.RemoveAt(oIdx);
                }
            }
            return Page();
        }

        Test.TestDate = DateTime.Now;

        // Set all question types to match test method before saving
        foreach (var q in Test.Questions)
        {
            q.Type = Test.Method;
        }

        // Save
        if (!ModelState.IsValid) return Page();
        Test.NumberOfQuestions = Test.Questions?.Count ?? 0;
        await _testService.UpdateTestAsync(Test);
        return RedirectToPage("Index");
    }
}