using Entities;

namespace Repositories
{
    public interface IUserRepository
    {
        
        Task<User?> GetUserById(int id);
        Task<User?> Login(ExistingUser existingUser);
        Task<User> Register(User user);
        Task Upadate(int id, User updateUser);
        Task<IEnumerable<User>> GetUsers();
    }
}