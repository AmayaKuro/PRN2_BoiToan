using Boitoan.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SPTS_Writer.Services.Abstraction;

namespace Boitoan.Pages.Home
{
    public class TestModel : PageModel
    {
        private readonly ITestService _testService;

        public TestModel(ITestService testService)
        {
            _testService = testService;
        }

		public IEnumerable<Boitoan.DAL.Entities.Test> Tests { get; set; } = new List<Boitoan.DAL.Entities.Test>();

		public async Task OnGetAsync()
        {
            Tests = await _testService.GetAllTestsAsync();
        }
    }
}
