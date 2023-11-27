using My_First_Finance_App.Models;

namespace My_First_Finance_App.Repositories
{
    public interface IUserRepository
    {
        User GetUserById(int userId);

        void CreateUser(User user);
        // Other user-related methods
    }
}
