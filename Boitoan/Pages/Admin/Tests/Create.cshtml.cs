using Boitoan.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services;

[Authorize(Roles = "Admin")]
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
        // Remove submit buttons
        ModelState.Remove("Test.Questions");
        ModelState.Remove("Test.Author");

        Test.TestDate = DateTime.Now;
        Test.Questions = new List<Question>();
        Test.Author = User.Identity?.Name ?? "Unknown";

        if (!ModelState.IsValid) return Page();
        Test.NumberOfQuestions = 0;
        await _testService.AddTestAsync(Test);
        return RedirectToPage("Index");
    }
}