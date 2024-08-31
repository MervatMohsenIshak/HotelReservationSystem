using HotelReservationSystem.Application.Abstractions;
using HotelReservationSystem.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelReservationSystem.Persistence.Authentication
{
    public sealed class JwtProvider : IJwtProvider
    {

        private readonly JwtOptions _options;

        public JwtProvider(IOptions<JwtOptions> options)
        {
            _options = options.Value;
        }
        public string GenerateToken(Customer customer)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, customer.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, customer.Email)
            };

            var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_options.JwtKey)),
            SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _options.JwtIssuer,
                _options.JwtAudience,
                claims,
                null,
                expires: DateTime.Now.AddMinutes(_options.TokenExpirationMinutes),
                signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public bool ValidateToken(string token)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes(_jwtOptions.JwtKey);
        //    try
        //    {
        //        tokenHandler.ValidateToken(token, new TokenValidationParameters
        //        {
        //            ValidateIssuer = true,
        //            ValidateAudience = true,
        //            ValidateLifetime = true,
        //            ValidateIssuerSigningKey = true,
        //            ValidIssuer = _jwtOptions.JwtIssuer,
        //            ValidAudience = _jwtOptions.JwtAudience,
        //            IssuerSigningKey = new SymmetricSecurityKey(key)
        //        }, out SecurityToken validatedToken);

        //        return validatedToken != null;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
    }
}
