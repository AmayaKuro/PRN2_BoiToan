using Boitoan.DAL.Entities;

namespace Boitoan.BLL.Abstraction;
public interface IUserService
{
    public Task<User?> GetUserByIdAsync(string id);
    public Task<IEnumerable<User>> GetAllUsersAsync();
    public Task AddUserAsync(User user);
    public Task UpdateUserAsync(User user);
}
