using Core.Repositories;
using DataAccess.Abstracts;
using DataAccess.Concreate.Contexts;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concreate.Repositories
{
    public class UserRepository : GenericRepository<User, ApplicationDbContext>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<User?> GetUserAsync(string username, string hashedPassword)
        {
            return await context.Users
                .FirstOrDefaultAsync(u => u.Username == username && u.Password == hashedPassword);
        }

        public async Task<bool> UsernameIsUniqueAsync(string username)
        {
            bool isExist = await context.Users
                .AnyAsync(u => u.Username == username);
            return !isExist;
        }
    }
}
