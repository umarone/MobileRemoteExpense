using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Configuration;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
namespace RemoteMultiSiteMobileBasedExpenseManager.Common
{
    public class MiscOperations
    {
        public static bool ValidateToken(string token)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); //.GetSection("Jwt")["Key"];
            bool isValid = false;
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {

                ValidateLifetime = false, // Because there is no expiration in the generated token
                ValidateAudience = false, // Because there is no audiance in the generated token
                ValidateIssuer = false,   // Because there is no issuer in the generated token
                ValidIssuer = config.GetSection("Jwt")["Issuer"],
                ValidAudience = config.GetSection("Jwt")["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetSection("Jwt")["Key"])) // The same key as the one that generate the token
            };

            try
            {
                var claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out _);
                isValid = true;
            }
            catch (SecurityTokenException)
            {
                Console.WriteLine("Invalid token.");
            }
            return isValid;
        }
        public static string GetClaimValue(ClaimsPrincipal principal, string Key)
        {
            return principal.FindFirstValue(Key);
        }
    }
}
