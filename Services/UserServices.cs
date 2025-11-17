using Entities;
using Repository;
namespace Services
{
    public class UserServices : IUserRepository,IPasswordServices, IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordServices _passwordServices;
        
        public UserServices(IUserRepository repository, IPasswordServices passwordServices)
        {
            _repository = repository;
            _passwordServices = passwordServices;
        }
      

       
        public User? GetUserById(int id)
        {
            return _repository.GetUserById(id);
        }
        public User? Login(ExistingUser existingUser)
        {
            return _repository.Login(existingUser);
        }
        public User Register(User user)
        {
            int passScore = _passwordServices.PasswordScore(user.Password);
            if (passScore < 2)
                return null;
            return _repository.Register(user);
        }
        public bool Upadate(int id, User updateUser)
        {
            int passScore = _passwordServices.PasswordScore(updateUser.Password);
            if (passScore < 2)
                return false;
            _repository.Upadate(id, updateUser);
            return true;

        }
        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        void IUserRepository.Upadate(int id, User updateUser)
        {
            throw new NotImplementedException();
        }

        public int PasswordScore(string password)
        {
            throw new NotImplementedException();
        }
    }
}
