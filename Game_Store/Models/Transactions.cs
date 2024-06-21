namespace Game_Store.Models;

public class Transactions
{
    public int TransactionsId { get; set; }
    public int UserId { get; set; }
    public Users User { get; set; }
    public int GameId { get; set; }
    public GameSummary Game { get; set; }
    public DateTime PurchaseDate { get; set; }
    public decimal Amount { get; set; }
}