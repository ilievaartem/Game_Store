using Game_Store.Models;

namespace Game_Store.Clients;

public class GameClients
{
    private readonly List<GameSummary> games =
    [
        new()
        {
            Id = 1,
            Name = "TBoI: Repentance",
            Genre = "Roguelike",
            Price = 1499M,
            ReleaseDate = new DateOnly(2021, 3, 31)
        },
        new()
        {
            Id = 2,
            Name = "CS2",
            Genre = "Shooter",
            Price = 0,
            ReleaseDate = new DateOnly(2023, 9, 27)
        },
        new()
        {
            Id = 3,
            Name = "Slay the Spire",
            Genre = "Roguelike",
            Price = 179M,
            ReleaseDate = new DateOnly(2017, 11, 14)
        }
    ];

    private readonly Genre[] genres = new GenreClients().GetGenres();
    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        ArgumentException.ThrowIfNullOrEmpty(game.GenreId);
        var genre = genres.Single(genre => genre.Id == int.Parse(game.GenreId));

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        
        games.Add(gameSummary);
    }
}