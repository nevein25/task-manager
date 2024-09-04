using ToDo.Application.Authentication.DTOs;

namespace ToDo.Application.Interfaces;
public interface IAuthenticationService
{
    Task<AuthResponseDto> Login(LoginDto loginDto);
    Task<AuthResponseDto> Register(RegisterDto registerDto);
}
