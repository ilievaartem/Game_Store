namespace Game_Store.Models;

public class Users
{
    public int UserId { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public decimal Balance { get; set; }
    public ICollection<Transactions> Transactions { get; set; }
    public ICollection<UserGame> UserGames { get; set; } 
}