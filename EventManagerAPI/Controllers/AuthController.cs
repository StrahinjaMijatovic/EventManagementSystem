using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using EventManagerAPI.Models;

namespace EventManagerAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthController(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var user = new IdentityUser { UserName = model.Email, Email = model.Email};
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
            return Ok(new { Message = "Korisnik uspesno registrovan." });
        
        return BadRequest(result.Errors);
    }

}

