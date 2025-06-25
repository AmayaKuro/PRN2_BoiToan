using Boitoan.DAL.Entities;

namespace Boitoan.DAL.Entities;

public class History : Base
{
    public Guid UserId { get; set; }
    public Guid TestId { get; set; }
    public string Result { get; set; }
    public TestStatus status { get; set; }
    public List<Answer> Answer { get; set; }
}

public enum TestStatus
{
    InProgress = 1,
    Completed = 2,
    Discard = 3 // ? instead of Discarded we delete the whole history?
}
