using Boitoan.DAL.Abstraction;
using Boitoan.DAL.Entities;

namespace Boitoan.DAL.Repositories.Abstraction
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}