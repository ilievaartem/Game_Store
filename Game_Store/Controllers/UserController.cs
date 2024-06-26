using Game_Store.Data;
using Game_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Store.Controllers;

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

    public async Task<Users> GetUserByIdAsync(int userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<IEnumerable<Users>> GetUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task UpdateUserBalanceAsync(int userId, decimal newBalance)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null)
        {
            user.Balance = newBalance;
            await _context.SaveChangesAsync();
        }
    }

    public async Task BuyGame(int userId, int gameId, decimal gamePrice)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user != null && user.Balance >= gamePrice)
        {
            user.Balance -= gamePrice;
            await _context.SaveChangesAsync();

            var transaction = new Transactions
            {
                UserId = userId,
                GameId = gameId,
                PurchaseDate = DateTime.UtcNow,
                Amount = gamePrice
            };
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }
    }
    
    public async Task<IEnumerable<Transactions>> GetTransactionsAsync()
    {
        return await _context.Transactions
            .Include(t => t.User)
            .Include(t => t.Game)
            .ToListAsync();
    }
}