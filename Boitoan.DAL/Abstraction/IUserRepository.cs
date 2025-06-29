using Boitoan.DAL.Entities;

namespace Boitoan.DAL.Abstraction
{
    public interface IUserRepository: IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}