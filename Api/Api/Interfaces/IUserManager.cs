using Api.Models;
using Api.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IUserManager
    {
        User Authenticate(LoginRequest loginReq);

        bool CreateUser(User UserForm);

    }
}
