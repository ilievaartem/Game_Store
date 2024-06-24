using Game_Store.Data;
using Game_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Store.Controllers
{
    public class GameClients
    {
        private readonly AppDbContext _context;

        public GameClients(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GameSummary>> GetGamesAsync()
        {
            return await _context.Games.Include(g => g.Genre).ToListAsync();
        }

        public async Task<GameSummary> GetGameAsync(int id)
        {
            return await _context.Games.Include(g => g.Genre).FirstOrDefaultAsync(g => g.GameId == id);
        }

        public async Task AddGameAsync(GameSummary game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGameAsync(GameSummary game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }
        
        public async Task<GameSummary> GetGameByIdAsync(int id)
        {
            return await _context.Games.Include(g => g.Genre).FirstOrDefaultAsync(g => g.GameId == id);
        }

    }
}