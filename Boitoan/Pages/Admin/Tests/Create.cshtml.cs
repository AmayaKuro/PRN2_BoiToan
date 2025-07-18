using Boitoan.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services;

public class CreateTestModel : PageModel
{
    private readonly TestService _testService;
    [BindProperty]
    public Test Test { get; set; } = new();

    public CreateTestModel(TestService testService)
    {
        _testService = testService;
    }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        Test.TestDate = DateTime.Now;

        if (!ModelState.IsValid) return Page();
        Test.Questions = new List<Question>();
        Test.NumberOfQuestions = 0;
        await _testService.AddTestAsync(Test);
        return RedirectToPage("Index");
    }
}