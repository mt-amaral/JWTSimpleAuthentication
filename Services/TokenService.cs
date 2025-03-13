using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWTSimpleAuthentication.Models;
using Microsoft.IdentityModel.Tokens;

namespace JWTSimpleAuthentication.Services;

public class TokenServices
{
     public string GenerateToken(User user)
     {
          var handler = new JwtSecurityTokenHandler();
          var key = Encoding.ASCII.GetBytes(Configuration.PrivateKay);
          var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);
          var tokenDescriptor = new SecurityTokenDescriptor()
          {
               Subject = GenerateClaimsIdentity(user),
               SigningCredentials = credentials,
               Expires = DateTime.UtcNow.AddHours(8),
          };
          var token = handler.CreateToken(tokenDescriptor);
          return handler.WriteToken(token);
     }

     private static ClaimsIdentity GenerateClaimsIdentity(User user)
     {
          var ci = new ClaimsIdentity();
          ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
          foreach (var role in user.Roles)
               ci.AddClaim(new Claim(ClaimTypes.Role, role));
          ci.AddClaim(new Claim("KeyClaim", "KeyValue"));
          return ci;
     }
}