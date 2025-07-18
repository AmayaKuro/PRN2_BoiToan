using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Boitoan.DAL.Entities;

namespace SPTS_Writer.Pages.Test
{
    public class CompleteModel : PageModel
    {
        public string MbtiResult { get; set; } = string.Empty;

        public async Task<IActionResult> OnGetAsync()
        {
            if (!TempData.ContainsKey("answers"))
                return RedirectToPage("/Test/Index");

            var answers = JsonConvert.DeserializeObject<Dictionary<int, string>>(TempData["answers"]!.ToString());
            if (answers == null || answers.Count == 0)
                return RedirectToPage("/Test/Index");

            // Count MBTI letters
            var mbtiCounts = new Dictionary<string, int>
            {
                ["E"] = 0,
                ["I"] = 0,
                ["S"] = 0,
                ["N"] = 0,
                ["T"] = 0,
                ["F"] = 0,
                ["J"] = 0,
                ["P"] = 0
            };

            foreach (var val in answers.Values)
            {
                if (mbtiCounts.ContainsKey(val))
                    mbtiCounts[val]++;
            }

            MbtiResult =
                (mbtiCounts["E"] >= mbtiCounts["I"] ? "E" : "I") +
                (mbtiCounts["S"] >= mbtiCounts["N"] ? "S" : "N") +
                (mbtiCounts["T"] >= mbtiCounts["F"] ? "T" : "F") +
                (mbtiCounts["J"] >= mbtiCounts["P"] ? "J" : "P");

            TempData.Clear(); // Optional: clear after finishing

            return Page();
        }
    }
}
