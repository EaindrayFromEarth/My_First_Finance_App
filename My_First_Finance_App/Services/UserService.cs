using My_First_Finance_App.Models;
using My_First_Finance_App.Repositories;
using System.Data.Entity;

namespace My_First_Finance_App.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ApplicationDbContext _context;

        public UserService(IUserRepository userRepository, ApplicationDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User GetUserById(int userId)
        {
            return _context.Users
                .Include(u => u.Transactions) // Include Transactions to load them along with the user
                .SingleOrDefault(u => u.UserId == userId);
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.SingleOrDefault(u => u.Username == username);
        }

        public void UpdateUser(User user)
        {
            var existingUser = _context.Users.Find(user.UserId);

            if (existingUser != null)
            {
                // Update properties of the existing user with the new values
                existingUser.Username = user.Username;

                // Save the changes
                _context.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public IEnumerable<User> GetAllUsers() 
        {
            return _context.Users.ToList();
        }

    }
}