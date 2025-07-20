using Boitoan.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services;

[Authorize(Roles = "Admin")]
public class TestsIndexModel : PageModel
{
    private readonly TestService _testService;
    public List<Test> Tests { get; set; } = new();

    public TestsIndexModel(TestService testService)
    {
        _testService = testService;
    }

    public async Task OnGetAsync()
    {
        Tests = (await _testService.GetAllTestsAsync()).ToList();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return BadRequest("Test ID cannot be null or empty.");
        }

        await _testService.DeleteTestAsync(id);
        return RedirectToPage();
    }
}