using Boitoan.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TestHistoryService
{
    private readonly HistoryRepository _historyRepository;

    public TestHistoryService(HistoryRepository historyRepository)
    {
        _historyRepository = historyRepository;
    }

    public void SaveTestResult(string userId, string testId, string result, TestStatus status, List<Answer> answers)
    {
        _historyRepository.SaveTestResult(userId, testId, result, status, answers);
    }
}
