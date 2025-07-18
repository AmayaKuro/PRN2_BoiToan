using Boitoan.BLL;
using Boitoan.DAL.Abstraction;
using Boitoan.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services;
using SPTS_Writer.Services.Abstraction;
using static System.Net.Mime.MediaTypeNames;

//[Authorize(Policy = Policy)]
namespace Boitoan.Pages.Admin;

public class IndexModel : PageModel
{
    private readonly UserService _userService;
    private readonly TestService _testService;
    private readonly HistoryService _historyService;

    [BindProperty]
    public int TotalUsers { get; set; }
    [BindProperty]
    public int TotalTests { get; set; }
    [BindProperty]
    public int TotalHistories { get; set; }

    public IndexModel(UserService userService, TestService testService, HistoryService historyService)
    {
        _userService = userService;
        _testService = testService;
        _historyService = historyService;
    }

    public async Task OnGetAsync()
    {
        TotalUsers = (await _userService.GetAllUsersAsync()).Count();
        TotalTests = (await _testService.GetAllTestsAsync()).Count();
        TotalHistories = ((int)await _historyService.GetTotalTestHistory());
    }

    public async Task<JsonResult> OnGetStatsAsync([FromQuery] int skip = 0, [FromQuery] int take = 5)
    {
        var histories = (await _historyService.GetHistoriesPagedAsync(skip, take)).ToList();
        var result = new List<HistoryDisplayDto>();
        foreach (var history in histories)
        {
            var user = await _userService.GetUserByIdAsync(history.UserId.ToString());
            var test = await _testService.GetTestByIdAsync(history.TestId.ToString());

            // Count each answer value
            var answerCounts = history.Answer?
                .GroupBy(a => a.Value)
                .ToDictionary(g => g.Key, g => g.Count()) ?? new Dictionary<string, int>();

            result.Add(new HistoryDisplayDto
            {
                TestName = test?.Method.ToString() ?? "Unknown",
                UserName = user?.Name ?? "Unknown",
                Result = history.Result,
                AnswerCounts = answerCounts,
                CreatedAt = history.CreatedAt
            });
        }

        return new JsonResult(result);
    }
}