using Boitoan.DAL.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace Boitoan.DAL.Entities;

public class History : Base
{
    public string UserId { get; set; } // string, not Guid
    public string TestId { get; set; } // string, not Guid

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
