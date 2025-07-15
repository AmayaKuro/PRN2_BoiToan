using Boitoan.DAL.Entities;

namespace SPTS_Writer.Services.Abstraction
{
    public interface ITestService
    {
        Task<Test?> GetTestByIdAsync(string id);
        Task<IEnumerable<Test>> GetAllTestsAsync();
        Task AddTestAsync(Test test);
        Task UpdateTestAsync(Test test);
        Task DeleteTestAsync(string id);
        Task<long> GetTotalTests();
    }
}
