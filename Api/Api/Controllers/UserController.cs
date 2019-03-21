using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.Models;
using Api.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserManager manager;
        public UserController(IUserManager manager)
        {
            this.manager = manager;

        }

        [HttpPost,AllowAnonymous, Route("Authenticate")]
        public  IActionResult Authenticate([FromBody]LoginRequest userParam)
        {
            var res = new ResponseData<User>();
            try
            {
                User user = manager.Authenticate(userParam);
                if (user == null)
                {

                    res.Code = 401;
                    res.Content = null;
                    res.IsSuccessful = false;
                    return Ok(res);
                }

                res.Code = 200;
                res.Content = user;
                res.IsSuccessful = true;
                return Ok(res);
            }
            catch(Exception e)
            {

                res.Code = 501;
                res.Content = null;
                res.IsSuccessful = false;
                return Ok(res);
            }
           
        }
       
      



    }
}