using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace RealState.JWTools;

public class JWTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JWTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
    {
        var claims = new List<Claim>();

        if(!string.IsNullOrWhiteSpace(model.Role))
            claims.Add(new Claim(ClaimTypes.Role, model.Role));
            

        if (!string.IsNullOrWhiteSpace(model.Username))
            claims.Add(new Claim("Username", model.Username));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"])),
            signingCredentials: creds);
        var expireDate = DateTime.UtcNow.AddMinutes(double.Parse(_configuration["Jwt:ExpireMinutes"]));
        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return new TokenResponseViewModel(tokenString, expireDate);
    }
}
