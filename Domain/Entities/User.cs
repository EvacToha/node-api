using System.ComponentModel.DataAnnotations;

namespace NodeApl.API.Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Username { get; set; }
    
    [Required] 
    [MaxLength(20)]
    public string Name { get; set; }
    
    [Required] 
    public string PasswordHash { get; set; }
    
}