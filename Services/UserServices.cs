using Entities;
using Repositories;

namespace Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        private readonly IPasswordServices _passwordServices;
        
        public UserServices(IUserRepository repository, IPasswordServices passwordServices)
        {
            _repository = repository;
            _passwordServices = passwordServices;
        }
      

       
        public async Task<User> GetUserById(int id)
        {
            return await _repository.GetUserById(id);
        }
        public async Task<User> Login(ExistingUser existingUser)
        {
            return await _repository.Login(existingUser);
        }
        public async Task< User> Register(User user)
        {
            int passScore = _passwordServices.PasswordScore(user.Password);
            if (passScore < 2)
                return null;
            return await _repository.Register(user);
        }
        public async Task<bool> Upadate(int id, User updateUser)
        {
            int passScore = _passwordServices.PasswordScore(updateUser.Password);
            if (passScore < 2)
                return false;
            await _repository.Upadate(id, updateUser);
            return true;

        }
        

       

        public int PasswordScore(string password)
        {
            throw new NotImplementedException();
        }

        

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _repository.GetUsers();
        }
    }
}
