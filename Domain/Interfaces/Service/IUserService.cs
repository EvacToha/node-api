using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Responses;

namespace NodeApl.API.Domain.Interfaces;

public interface IUserService
{
    Task<RegisterResponse> RegisterAsync(UserRegisterDto userDto);
    Task<LoginResponse> LoginAsync(UserLoginDto userDto);
}