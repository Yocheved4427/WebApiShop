using Entities;

namespace Services
{
    public interface IUserServices
    {
        Task<User> GetUserById(int id);
        Task<User> Login(ExistingUser existingUser);
        Task<User> Register(User user);
        Task<bool> Upadate(int id, User updateUser);
        Task<IEnumerable<User>> GetUsers();
    }
}