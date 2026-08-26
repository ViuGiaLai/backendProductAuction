using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs.Auth;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto request)
    {
        return Ok(new { Token = "sample-jwt-token" });
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDto request)
    {
        return Ok(new { Message = "User registered successfully" });
    }
}
