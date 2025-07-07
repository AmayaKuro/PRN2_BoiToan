using Boitoan.DAL.Entities;
using SPTS_Writer.Services.Abstraction;
using Boitoan.DAL.Abstraction;

namespace SPTS_Writer.Services
{
    public class TestService : ITestService
    {
        private readonly IRepository<Test> _testRepository;
        private readonly IRepository<History> _testHistoryRepository;

        public TestService(IRepository<Test> testRepository, IRepository<History> testHistoryRepository)
        {
            _testRepository = testRepository;
            _testHistoryRepository = testHistoryRepository;
        }

        public async Task<Test?> GetTestByIdAsync(string id)
        {
            return await _testRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Test>> GetAllTestsAsync()
        {
            return await _testRepository.GetAllAsync();
        }

        public async Task AddTestAsync(Test test)
        {
            await _testRepository.AddAsync(test);
            await _testRepository.SaveChangesAsync();
        }

        public async Task UpdateTestAsync(Test test)
        {
            await _testRepository.UpdateAsync(test.Id.ToString(), test);
            await _testRepository.SaveChangesAsync();
        }

        public async Task DeleteTestAsync(string id)
        {
            await _testRepository.DeleteAsync(id);
            await _testRepository.SaveChangesAsync();
        }

        public async Task<long> GetTotalTests()
        {
            return await _testRepository.Count();
        }

        public async Task<long> GetTotalTestHistory()
        {
            return await _testHistoryRepository.Count();
        }
    }
}