
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Lab9.Models;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private UserManager<IdentityUser> _user;
    private IConfiguration _configuration;

    public UserController(UserManager<IdentityUser> userManager, IConfiguration configuration)
    {
        _user = userManager;
        _configuration = configuration;
    }

    [HttpPost]
    public async Task<IActionResult> Token([FromBody] UserDto dto)
    {
        var user = await _user.FindByEmailAsync(dto.UserName);
        if (user == null || !await _user.CheckPasswordAsync(user, dto.Password))
        {
            return BadRequest("Invalid username or password");
        }

        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
        };
        foreach (var role in await _user.GetRolesAsync(user))
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: _configuration["Tokens:Issuer"],
            audience: _configuration["Tokens:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds
        );

        return Ok(new
        {
            token = new JwtSecurityTokenHandler().WriteToken(token),
            expiration = token.ValidTo
        });
    }
}
