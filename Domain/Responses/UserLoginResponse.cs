namespace NodeApl.API.Domain.Responses;

public class UserLoginResponse
{
    public bool Success { get; set; }
    public string Message { get; set; }
    public string Token { get; set; }
}