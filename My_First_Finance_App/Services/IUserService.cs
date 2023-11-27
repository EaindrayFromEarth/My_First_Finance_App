using My_First_Finance_App.Models;

namespace My_First_Finance_App.Services
{
    public interface IUserService
    {

        User GetUserById(int userId);
        User GetUserByUsername(string username);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        IEnumerable<User> GetAllUsers();
        void CreateUser(User user);
    }

}
