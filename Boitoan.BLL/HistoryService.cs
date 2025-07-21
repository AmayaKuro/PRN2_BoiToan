using Boitoan.DAL.Entities;
using SPTS_Writer.Services.Abstraction;
using Boitoan.DAL.Abstraction;

namespace SPTS_Writer.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IRepository<History> _testHistoryRepository;

        public HistoryService(IRepository<History> testHistoryRepository)
        {
            _testHistoryRepository = testHistoryRepository;
        }

        public async Task<long> GetTotalTestHistory()
        {
            return await _testHistoryRepository.Count();
        }

        public async Task<IEnumerable<History>> GetHistoriesPagedAsync(int skip, int take)
        {
            var all = await _testHistoryRepository.GetAllAsync();
            return all
                .OrderByDescending(h => h.CreatedAt)
                .Skip(skip)
                .Take(take);
        }
        public async Task<IEnumerable<History>> GetHistoriesByUserIdAsync(string userId)
        {
            var all = await _testHistoryRepository.GetAllAsync();
            return all
                .Where(h => h.UserId == userId)
                .OrderByDescending(h => h.CreatedAt);
        }

    }
}