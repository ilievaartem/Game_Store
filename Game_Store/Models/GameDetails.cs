using System.ComponentModel.DataAnnotations;

namespace Game_Store.Models;

public class GameDetails
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public required string Name { get; set; }
    
    [Required(ErrorMessage = "The Genres field is required")]
    public string? GenreId { get; set; }
    
    [Range(0, 4000)]
    public decimal Price { get; set; }
    
    public DateOnly ReleaseDate { get; set; }
}