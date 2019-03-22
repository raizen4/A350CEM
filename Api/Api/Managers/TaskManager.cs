﻿using Api.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Api.Managers
{
    public class TaskManager : ITaskManager
    {
        private readonly IDatabaseService dbService;
        private AppSettings apiConstants;

        public TaskManager(IDatabaseService dbService, IOptions<AppSettings> constants)
        {
            this.dbService = dbService;
            this.apiConstants = constants.Value;
        }

        public User Authenticate(LoginRequest req)
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
    }
}