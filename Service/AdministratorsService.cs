using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Data;

using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Options;
using System.Text;
using System.Collections.Generic;

namespace CheckAttendanceAPI.Service
{
    public class AdministratorsService : BaseService, IAuthentication
    {
        private readonly AppSettings key;

        public AdministratorsService(Context context, IOptions<AppSettings> setting) : base(context) => key = setting.Value;

        //Check Login
        public string Authenticate(Administrators administrators)
        {
            Administrators result = GetById(administrators.UserId);
            if (result != null)
            {
                if (result.Password == administrators.Password && result.Status == true)
                {
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenKey = Encoding.ASCII.GetBytes(this.key.MyKey);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, result.UserId)
                    }),
                        Expires = DateTime.UtcNow.AddHours(1),
                        SigningCredentials = new SigningCredentials(
                                                    new SymmetricSecurityKey(tokenKey),
                                                        SecurityAlgorithms.HmacSha256Signature)
                    };
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    return tokenHandler.WriteToken(token);
                }
            }
            return null;
        }

        //Insert
        public void Insert(Administrators administrators)
        {
            context.Administrators.Add(administrators);
        }

        //Update
        public void Update(Administrators administrators){}
      
        //Get By Id
        public Administrators GetById(string id)
        {
            return context.Administrators.FirstOrDefault(p => p.UserId == id);
        }
    }
}