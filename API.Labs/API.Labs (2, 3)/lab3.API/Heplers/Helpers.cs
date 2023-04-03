using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace lab3.API.Heplers;

public class Helpers : IHelpers
{
    private readonly IConfiguration _configuration;
    public Helpers(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public SecurityKey GetSecurityKey()
    {
        var secretKeyString = _configuration.GetValue<string>("SecretKey") ?? "";
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
        var securityKey = new SymmetricSecurityKey(secretKeyInBytes);
        return securityKey;
    }
    public string GenerateToken(IList<Claim> claims)
    {
        SecurityKey securityKey = GetSecurityKey();
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        DateTime tokenExpiryDate = DateTime.Now.AddMinutes(15);

        var jwt = new JwtSecurityToken(claims: claims,
                                        expires: tokenExpiryDate,
                                        signingCredentials: signingCredentials);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(jwt);
        return token;
    }
}
