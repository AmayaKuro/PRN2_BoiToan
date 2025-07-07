using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Boitoan.BLL;
using SPTS_Writer.Services;
using Boitoan.DAL.Entities;
using Boitoan.DAL.Abstraction;
using Microsoft.AspNetCore.Mvc;

//[Authorize(Policy = Policy)]
namespace Boitoan.Pages.Admin;

public class IndexModel : PageModel
{
    private readonly UserService _userService;
    private readonly TestService _testService;

    [BindProperty]
    public int TotalUsers { get; set; }
    [BindProperty]
    public int TotalTests { get; set; }
    [BindProperty]
    public int TotalHistories { get; set; }

    public IndexModel(UserService userService, TestService testService)
    {
        _userService = userService;
        _testService = testService;
    }

    public async Task OnGetAsync()
    {
        TotalUsers = (await _userService.GetAllUsersAsync()).Count();
        TotalTests = (await _testService.GetAllTestsAsync()).Count();
        //TotalHistories = (await _historyRepository.GetAllAsync()).Count();
    }
}