using Boitoan.DAL.Entities;

namespace SPTS_Writer.Services.Abstraction
{
    public interface IHistoryService
    {
        Task<long> GetTotalTestHistory();
        Task<IEnumerable<History>> GetHistoriesPagedAsync(int skip, int take);
    }
}