using Entities;

namespace Repository
{
    public interface IUserRepository
    {
        void Delete(int id);
        User? GetUserById(int id);
        User? Login(ExistingUser existingUser);
        User Register(User user);
        void Upadate(int id, User updateUser);
    }
}