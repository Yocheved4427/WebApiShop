using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Text.Json;
namespace Repositories


{

    public class UserRepository : IUserRepository
    {
        public readonly ApiShopContext _context;
        public UserRepository(ApiShopContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<User?> Login(ExistingUser existingUser)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == existingUser.Email && u.Password == existingUser.Password);

        }
        public async Task<User> Register(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;

        }
        public async Task Upadate(int id, User updateUser)
        {
            _context.Users.Update(updateUser);
            await _context.SaveChangesAsync();

        }
       
    }
}
