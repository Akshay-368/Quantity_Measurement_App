using Microsoft.AspNetCore.Mvc;
using QuantityMeasurement.BusinessLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;


namespace QuantityMeasurement.API.Controllers;
[ApiController]
[Route("api/[controller]")]
[AllowAnonymous]
[EnableRateLimiting("fixedWindowLimiter")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(string username, string password)
    {
        await _authService.RegisterAsync(username, password);
        return Ok("User created");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string username, string password)
    {
        var token = await _authService.LoginAsync(username, password);
        return Ok(token);
    }
}

