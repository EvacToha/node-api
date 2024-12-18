using NodeApl.API.Domain.DTOs;
using NodeApl.API.Domain.Responses;

namespace NodeApl.API.Domain.Interfaces;

public interface IUserService
{
    Task<UserRegisterResponse> RegisterUserAsync(UserRegisterDto userDto);
    Task<UserLoginResponse> LoginUserAsync(UserLoginDto userDto);
}