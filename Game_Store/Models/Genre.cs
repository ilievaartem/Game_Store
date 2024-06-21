namespace Game_Store.Models;

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public ICollection<GameSummary> Games { get; set; }
}