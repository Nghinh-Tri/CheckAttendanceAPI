using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
namespace CheckAttendanceAPI.Service
{
    public class AdministratorsService : IAuthentication
    {
        private readonly Context context;
        private readonly AppSettings key;
        public AdministratorsService(Context context, IOptions<AppSettings> setting)
        {
            this.context = context; 
            this.key = setting.Value;
        }

        public string Authenticate(Administrators administrators)
        {
            Administrators account = context.Administrators.Find(administrators.UserId);
            if (account.Password == administrators.Password)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes(this.key.MyKey);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, account.UserId)
                    }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(
                                                new SymmetricSecurityKey(tokenKey), 
                                                    SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            return null;
        }
    }
}