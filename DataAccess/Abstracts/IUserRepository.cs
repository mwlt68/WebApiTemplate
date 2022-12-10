using Core.Repositories;
using DataAccess.Entities;

namespace DataAccess.Abstracts
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User?> GetUserAsync(string username, string hashedPassword);
    }
}
