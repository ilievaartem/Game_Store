namespace Game_Store.Models;

public class UserGame
{
    public int UserId { get; set; }
    public Users User { get; set; }

    public int GameId { get; set; }
    public GameSummary Game { get; set; }
}
