using Boitoan.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services;

public class TestDetailsModel : PageModel
{
    private readonly TestService _testService;
    public Test Test { get; set; }

    public TestDetailsModel(TestService testService)
    {
        _testService = testService;
    }

    public async Task<IActionResult> OnGetAsync(string id)
    {
        Test = await _testService.GetTestByIdAsync(id);
        if (Test == null)
            return NotFound();
        return Page();
    }
}