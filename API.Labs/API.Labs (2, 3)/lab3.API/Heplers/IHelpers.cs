using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace lab3.API;

public interface IHelpers
{
    SecurityKey GetSecurityKey();
    string GenerateToken(IList<Claim> claims);
}
