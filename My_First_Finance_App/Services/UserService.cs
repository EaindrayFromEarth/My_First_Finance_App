using My_First_Finance_App.Models;
using My_First_Finance_App.Repositories;

namespace My_First_Finance_App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }

        // Implement other user-related methods
    }
}
