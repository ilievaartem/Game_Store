using Game_Store.Data;
using Game_Store.Models;

namespace Game_Store.Controllers
{
    public class UserController
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddUserAsync(Users newUser)
        {
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
        }
    }
}