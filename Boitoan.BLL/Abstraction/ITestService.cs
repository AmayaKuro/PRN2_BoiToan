using Boitoan.DAL.Entities;

namespace SPTS_Writer.Services.Abstraction
{
    public interface ITestService
    {

        public  Task<Test?> GetTestByIdAsync(string id);

        public  Task<IEnumerable<Test>> GetAllTestsAsync();

        public  Task AddTestAsync(Test test);

        public  Task UpdateTestAsync(Test test);

        public  Task DeleteTestAsync(string id);
        Task<long> GetTotalTests();
    }
}
