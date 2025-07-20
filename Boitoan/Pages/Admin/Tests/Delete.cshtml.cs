using Boitoan.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services;

[Authorize(Roles = "Admin")]
public class DeleteTestModel : PageModel
{
    private readonly TestService _testService;
    [BindProperty]
    public Test Test { get; set; }

    public DeleteTestModel(TestService testService)
    {
        _testService = testService;
    }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        Test = await _testService.GetTestByIdAsync(id);
        if (Test == null) return NotFound();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _testService.DeleteTestAsync(Test.Id);
        return RedirectToPage("Index");
    }
}