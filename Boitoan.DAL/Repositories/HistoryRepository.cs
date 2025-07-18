using Boitoan.DAL.Entities;
using MongoDB.Driver;

public class HistoryRepository
{
    private readonly MongoDbContext _context;

    public HistoryRepository(MongoDbContext context)
    {
        _context = context;
    }

    public void SaveTestResult(string userId, string testId, string result, TestStatus status, List<Answer> answers)
    {
        var history = new History
        {
            UserId = userId,
            TestId = testId,
            Result = result,
            status = status,
            Answer = answers,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Histories.InsertOne(history);
    }
}