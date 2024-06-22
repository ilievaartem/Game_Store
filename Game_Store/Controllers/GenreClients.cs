using Game_Store.Data;
using Game_Store.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Store.Controllers
{
    public class GenreClients
    {
        private readonly AppDbContext _context;

        public GenreClients(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetGenresAsync()
        {
            return await _context.Genre.ToListAsync();
        }
    }
}