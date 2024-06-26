using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Game_Store.Models;

public class UserDetails
{
    public int UserId { get; set; }
        
    [Required]
    [StringLength(100)]
    public string UserName { get; set; }
    
    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]    
    public string Email { get; set; }
        
    [Required(ErrorMessage = "Password is required")]
    [StringLength(20, ErrorMessage = "Must be between 5 and 20 characters", MinimumLength = 5)]
    [DataType(DataType.Password)]
    public string PasswordHash { get; set; }
    
    public decimal Balance { get; set; }

    public ICollection<Transactions> Transactions { get; set; }
}