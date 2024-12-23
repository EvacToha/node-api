namespace NodeApl.API.Domain.Responses;

/// <summary>
/// Ответ на регистрацию
/// </summary>
public class RegisterResponse
{
    /// <summary>
    /// Статус выполнения
    /// </summary>
    public bool Success { get; set; }
    /// <summary>
    /// Сообщение
    /// </summary>
    public string Message { get; set; }
}