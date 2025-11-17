using Entities;

namespace Services
{
    public interface IUserServices
    {
        void Delete(int id);
        User? GetUserById(int id);
        User? Login(ExistingUser existingUser);
        User Register(User user);
        bool Upadate(int id, User updateUser);
    }
}