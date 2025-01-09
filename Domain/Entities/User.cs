using System.ComponentModel.DataAnnotations;

namespace NodeApl.API.Domain.Entities;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required] [MaxLength(20)]
    public string Login { get; set; }
    
    [Required] [MaxLength(20)]
    public string FullName { get; set; }
    
    [Required] 
    public string PasswordHash { get; set; }
    
}