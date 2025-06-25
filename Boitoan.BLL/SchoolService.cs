using Boitoan.DAL.Entities;
using Boitoan.DAL.Abstraction;

namespace SPTS_Writer.Services
{
    public class SchoolService
    {
        private readonly IRepository<School> _schoolRepository;
        public SchoolService(IRepository<School> schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }
        public async Task<School?> GetTestByIdAsync(string id)
        {
            return await _schoolRepository.GetByIdAsync(id);
        }
        public async Task<IEnumerable<School>> GetAllTestsAsync()
        {
            return await _schoolRepository.GetAllAsync();
        }

        public async Task AddTestAsync(School test)
        {
            await _schoolRepository.AddAsync(test);
            await _schoolRepository.SaveChangesAsync();
        }

        public async Task UpdateTestAsync(School test)
        {
            await _schoolRepository.UpdateAsync(test.Id.ToString(), test);
            await _schoolRepository.SaveChangesAsync();
        }
        public async Task DeleteTestAsync(string id)
        {
            await _schoolRepository.DeleteAsync(id);
            await _schoolRepository.SaveChangesAsync();
        }


    }
}
