namespace Game_Store.Models;

public class GameSummary
{
    public int GameId { get; set; }
    public required string Name { get; set; }
    public required string Genres { get; set; }
    public decimal Price { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public int? GenreID { get; set; }
    public Genre Genre { get; set; }
    public ICollection<UserGame> UserGames { get; set; } 
}