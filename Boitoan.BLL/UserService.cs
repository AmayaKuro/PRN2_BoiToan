using Boitoan.DAL.Repositories;
using Boitoan.DAL.Entities;
using Boitoan.DAL.Abstraction;
using Boitoan.BLL.Abstraction;

namespace Boitoan.BLL
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(MongoDbContext context)
        {
            _userRepository = new UserRepository(context);
        }

        public async Task<User?> GetUserByIdAsync(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userRepository.GetAllAsync();
        }

        public async Task AddUserAsync(User test)
        {
            await _userRepository.AddAsync(test);
            await _userRepository.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User test)
        {
            await _userRepository.UpdateAsync(test.Id.ToString(), test);
            await _userRepository.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(string id)
        {
            await _userRepository.DeleteAsync(id);
            await _userRepository.SaveChangesAsync();
        }

    }
}
