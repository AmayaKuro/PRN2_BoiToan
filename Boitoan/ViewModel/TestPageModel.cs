using Boitoan.DAL.Entities;

namespace Boitoan.ViewModel;

public class TestPageModel
{
    public Test Test { get; set; }
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public Question CurrentQuestion { get; set; }
    public Dictionary<int, string> SelectedAnswers { get; set; } = new();
}