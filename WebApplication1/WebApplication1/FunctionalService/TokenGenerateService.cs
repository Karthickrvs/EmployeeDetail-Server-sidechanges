using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.FunctionalService;

public class TokenGenerateService : ITokenGenerateService
{
    private readonly IConfiguration _configuration;

    public TokenGenerateService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(string username)
    {
        var secret =
            _configuration["JwtSettings:Secret"];

        var tokenHandler =
            new JwtSecurityTokenHandler();

        var key =
            Encoding.ASCII.GetBytes(secret);

        var tokenDescriptor =
            new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                new[]
                {
                    new Claim(
                        ClaimTypes.Name,
                        username)
                }),

                Expires =
                    DateTime.UtcNow.AddHours(1),

                SigningCredentials =
                    new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms
                        .HmacSha256Signature)
            };

        var token =
            tokenHandler.CreateToken(
                tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}