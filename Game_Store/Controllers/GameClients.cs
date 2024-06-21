using Game_Store.Models;

namespace Game_Store.Controllers;

public class GameClients(HttpClient httpClient)
{
    private readonly List<GameSummary> games =
    [
        new()
        {
            GameId = 1,
            Name = "TBoI: Repentance",
            Genres = "Roguelike",
            Price = 1499M,
            ReleaseDate = new DateOnly(2021, 3, 31)
        },
        new()
        {
            GameId = 2,
            Name = "CS2",
            Genres = "Shooter",
            Price = 0,
            ReleaseDate = new DateOnly(2023, 9, 27)
        },
        new()
        {
            GameId = 3,
            Name = "Slay the Spire",
            Genres = "Roguelike",
            Price = 179M,
            ReleaseDate = new DateOnly(2017, 11, 14)
        }
    ];

    private readonly Genre[] genres = new GenreClients(httpClient).GetGenres();
    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreById(game.GenreId);

        var gameSummary = new GameSummary
        {
            GameId = games.Count + 1,
            Name = game.Name,
            Genres = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
        
        games.Add(gameSummary);
    }

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryById(id);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genres, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.GameId,
            Name = game.Name,
            GenreId = genre.Id.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }

    public void UpdateGame(GameDetails updatedGame)
    {
        var genre = GetGenreById(updatedGame.GenreId);
        GameSummary existingGame = GetGameSummaryById(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genres = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }
    public void DeleteGame(int id)
    {
        var game = GetGameSummaryById(id);
        games.Remove(game);
    }
    
    private GameSummary GetGameSummaryById(int id)
    {
        GameSummary? game = games.Find(game => game.GameId == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreById(string? id)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);
        return genres.Single(genre => genre.Id == int.Parse(id));
    }
}