using System.ComponentModel.DataAnnotations;

namespace NodeApl.API.Domain.DTOs;

public class UserRegisterDto
{
   
    [Required]
    [MinLength(5)]
    public string Login { get; set; }
    
    [Required]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).{8,}$")]
    public string Password { get; set; }
    [Required]
    public string FullName { get; set; }
}