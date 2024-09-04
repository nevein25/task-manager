using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Authentication.DTOs;
using ToDo.Application.Interfaces;

namespace TodoManager.API.Controllers;
[Route("api/auth")]
[ApiController]
public class AccountsController : ControllerBase
{
    private readonly IAuthenticationService _authenticationService;

    public AccountsController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("register")]
    public async Task<AuthResponseDto> Register(RegisterDto registerDto)
    {
        return await _authenticationService.Register(registerDto);
    }

    [HttpPost("login")]
    public async Task<AuthResponseDto> Login(LoginDto loginDto)
    {
        return await _authenticationService.Login(loginDto);
    }
}