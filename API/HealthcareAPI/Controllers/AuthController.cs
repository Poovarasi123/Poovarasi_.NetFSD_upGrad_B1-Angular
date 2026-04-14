using Microsoft.AspNetCore.Mvc;
    using HealthcareAPI.Services;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;

    public AuthController(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    [HttpPost("login")]
    public IActionResult Login(string username, string password)
    {
        if (username == "admin" && password == "123")
        {
            var token = _jwtService.GenerateToken(username, "Admin");
            return Ok(token);
        }

        return Unauthorized();
    }
}