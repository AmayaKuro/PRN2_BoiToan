using MongoDB.Driver;
using Boitoan.DAL.Repositories.Abstraction;
using Boitoan.DAL.Entities;

namespace Boitoan.DAL.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(MongoDbContext context) : base(context) { }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await FindAsync(u => u.Email == email);
    }
}