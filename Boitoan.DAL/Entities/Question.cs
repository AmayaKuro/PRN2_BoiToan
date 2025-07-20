namespace Boitoan.DAL.Entities;

public class Question
{
    public int Id { get; set; }
    public string Detail { get; set; }
    public TestMethod Type { get; set; } // e.g., "M/B/T", "D/T/B/I"
    public List<Option> Options { get; set; } = new List<Option>();
}
