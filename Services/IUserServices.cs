using Entities;

namespace UserServices
{
    public interface IUserServices
    {
        Task<User?> GetUserById(int id);
        Task<User?> Login(ExistingUser existingUser);
        Task<User?> Register(User user);
        Task<bool> Update(int id, User updateUser);
        Task<IEnumerable<User>> GetUsers();
    }
}