namespace NodeApl.API.Domain.Responses;

/// <summary>
/// Ответ на вход
/// </summary>
public class LoginResponse
{
    /// <summary>
    /// Статус выполнения
    /// </summary>
    public bool Success { get; set; }
    /// <summary>
    /// Сообщение
    /// </summary>
    public string Message { get; set; }
    /// <summary>
    /// Токен
    /// </summary>
    public string Token { get; set; }
}