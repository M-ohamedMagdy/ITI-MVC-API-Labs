using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace lab3.API.Heplers;

public static class StaticHelpers
{
    public static SecurityKey GetSecurityKeyExt(this IConfiguration configuration)
    {
        var secretKeyString = configuration.GetValue<string>("SecretKey") ?? "";
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
        var securityKey = new SymmetricSecurityKey(secretKeyInBytes);
        return securityKey;
    }
}
