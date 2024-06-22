using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Game_Store.Models;

public class TransactionDetails
{
    public int TransactionId { get; set; }
        
    [Required]
    public int GameId { get; set; }
        
    [ForeignKey("GameId")]
    public GameSummary Game { get; set; }
        
    [Required]
    public int UserId { get; set; }
        
    [ForeignKey("UserId")]
    public Users User { get; set; }
        
    [Required]
    public DateTime TransactionDate { get; set; }
        
    [Required]
    public decimal Price { get; set; }
}