using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace lab3.API;

public interface IHelpers
{
    string GenerateToken(IList<Claim> claims);
}
