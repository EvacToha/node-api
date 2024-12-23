using System.ComponentModel.DataAnnotations;

namespace NodeApl.API.Domain.DTOs;

/// <summary>
/// Пользователь
/// </summary>
public class UserLoginDto
{
    /// <summary>
    /// Логин
    /// </summary>
    [Required]
    public string Login { get; set; }
    /// <summary>
    /// Пароль
    /// </summary>
    [Required]
    public string Password { get; set; }
}