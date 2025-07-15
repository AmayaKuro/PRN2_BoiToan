using Microsoft.AspNetCore.Mvc.RazorPages;
using Boitoan.DAL;
using Boitoan.DAL.Entities;
using MongoDB.Driver;

namespace SPTS_Writer.Pages.Test
{
    public class ListModel : PageModel
    {
        private readonly MongoDbContext _context;

        public List<Boitoan.DAL.Entities.Test> Tests { get; set; } = new();

        public ListModel(MongoDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Tests = _context.Tests.Find(_ => true).ToList();
        }
    }
}