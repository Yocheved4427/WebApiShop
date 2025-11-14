using Entities;
using Repository;
namespace Services
{
    public class UserServices
    {
        UserRepository userRepository = new UserRepository();
        private PasswordServices passwordService = new PasswordServices();
        public User? GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }
        public User? Login(ExistingUser existingUser)
        {
            return userRepository.Login(existingUser);
        }
        public User? Register(User user)
        {
            int passScore = passwordService.PasswordScore(user.Password);
                if (passScore < 2)
                return null;
            return userRepository.Register(user);
        }
        public bool Upadate(int id, User updateUser)
        {
            int passScore = passwordService.PasswordScore(updateUser.Password);
            if (passScore < 2)
                return false;
            userRepository.Upadate(id, updateUser);
            return true;

        }
        public void Delete(int id)
        {
            userRepository.Delete(id);
        }
    }
}
