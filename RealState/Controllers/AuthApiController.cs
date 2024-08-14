using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealState.JWTools;
using System.Security.Claims;

namespace RealState.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AuthApiController : ControllerBase
{
    private readonly JWTokenGenerator _tokenGenerator;

    public AuthApiController(JWTokenGenerator tokenGenerator)
    {
        _tokenGenerator = tokenGenerator;
    }

    [HttpGet("validate")]
    [Authorize]
    public IActionResult ValidateToken()
    {
        var userClaims = User.Claims.ToList();
        var username = User.FindFirstValue(ClaimTypes.Name);
        var role = User.FindFirstValue(ClaimTypes.Role);

        return Ok(new { Username = username, Role = role });
    }
}
