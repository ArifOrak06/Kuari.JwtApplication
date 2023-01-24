using Kuari.JwtApplication.Back.Core.Application.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Kuari.JwtApplication.Back.İnfrastructure.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseDto GenerateToken(CheckUserResponseDto dto)
        {
            var claims = new List<Claim>();

            if (!string.IsNullOrEmpty(dto.Role))
                claims.Add(new Claim(ClaimTypes.Role, dto.Role));

            claims.Add(new Claim(ClaimTypes.NameIdentifier, dto.Id.ToString()));

            if (!string.IsNullOrEmpty(dto.Username))
                claims.Add(new Claim("Username", dto.Username));


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JsonWebTokenDefaults.Key));
            SigningCredentials _signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expireDate = DateTime.UtcNow.AddMinutes(JsonWebTokenDefaults.Expire);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: JsonWebTokenDefaults.ValidIssuer, audience:JsonWebTokenDefaults.ValidAudience,
                claims:claims, 
                notBefore: DateTime.UtcNow, 
                signingCredentials: _signingCredentials
                
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
          
            return new TokenResponseDto(handler.WriteToken(jwtSecurityToken),expireDate);

        }
    }
}
