namespace Boitoan.DAL.Entities;

public class Test : Base
{
    public TestMethod Method { get; set; }
    public string Author { get; set; }
    public DateTime TestDate { get; set; }
    public int NumberOfQuestions { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();// why putting this private at fist?
}

public enum TestMethod
{
    MBTI = 12,
    DISC = 13
}
