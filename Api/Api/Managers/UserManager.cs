using Api.Interfaces;
using Api.Models;
using Api.ServiceModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IDatabaseService dbService;
        private AppSettings apiConstants;

        public UserManager(IDatabaseService dbService, IOptions<AppSettings> constants)
        {
            this.dbService = dbService;
            this.apiConstants = constants.Value;
        }

        public  User Authenticate(LoginRequest req)
        {
            var user = dbService.GetUser(req.Code);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(apiConstants.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.UserData, user.Name),
                    new Claim(ClaimTypes.UserData,user.Token)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            user.Password = null;

            return user;
        }

        public bool CreateUser(User userForm)
        {

            try
            {
                var result = dbService.CreateUser(userForm);
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
