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

    public History SaveTestResult(string userId, string testId, string result, TestStatus status, List<Answer> answers)
    {
        return _historyRepository.SaveTestResult(userId, testId, result, status, answers);  
    }
}
