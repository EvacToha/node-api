using System.ComponentModel.DataAnnotations;

namespace NodeApl.API.Domain.DTOs;

public class UserLoginDto
{
    [Required]
    public string Login { get; set; }

    [Required]
    
    public string Password { get; set; }
}