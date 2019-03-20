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
        IEmployeeManager manager;
        public UserController(IEmployeeManager manager)
        {
            this.manager = manager;

        }

        [HttpPost,Route("authenticate")]
        public IActionResult Authenticate([FromBody]LoginRequest userParam)
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
       
        [HttpGet, AllowAnonymous,Route("CreateEmployee")]
        public IActionResult CreateUser([FromBody] EmployeeFormRequest req)
        {
            var res = new BaseResponse();
            try
            {
                var createdUser = manager.CreateEmployee(req);
                if (createdUser)
                {

                    res.Code = 401;
                    res.IsSuccessful = false;
                    return Ok(res);
                }


                res.Code = 200;
                res.IsSuccessful = true;
                return Ok(res);
            }
            catch (Exception e)
            {

                res.Code = 501;
                res.IsSuccessful = false;
                return Ok(res);
            }
            
        
        }



    }
}