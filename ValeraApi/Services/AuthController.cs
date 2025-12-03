using Microsoft.AspNetCore.Mvc;
using ValeraApi.DTOs;
using ValeraApi.Services;

namespace ValeraApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserService _userService;
    private readonly TokenService _tokenService;

    public AuthController(UserService userService, TokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterDto dto)
    {
        var user = await _userService.RegisterAsync(dto.Username, dto.Email, dto.Password);
        if (user == null)
            return BadRequest("Email already exists");
        return Ok(new { message = "User registered" });
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginDto dto)
    {
        var user = _userService.Authenticate(dto.Email, dto.Password);
        if (user == null)
            return Unauthorized();

        var token = _tokenService.GenerateToken(user);
        return Ok(new
        {
            token,
            user = new { user.Id, user.Email, user.Role }
        });
    }
}