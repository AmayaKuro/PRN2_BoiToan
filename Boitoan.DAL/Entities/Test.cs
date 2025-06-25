using Boitoan.DAL.Entities;

namespace Boitoan.DAL.Entities;

public class Test : Base
{
    public string Method { get; set; }
    public string Author { get; set; }
    public DateTime TestDate { get; set; }
    public int NumberOfQuestions { get; set; }
    List<Question> Questions { get; set; }
}
