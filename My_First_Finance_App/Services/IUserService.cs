using My_First_Finance_App.Models;

namespace My_First_Finance_App.Services
{
    public interface IUserService
    {
        User GetUserById(int userId);
        // Other user-related methods
    }

}
