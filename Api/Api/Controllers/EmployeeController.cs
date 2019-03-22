using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.ServiceModels;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly IEmployeeManager manager;



        public EmployeeController(IEmployeeManager manager)
        {
            this.manager = manager;
        }


        [HttpGet, Authorize, Route("GetEmployees")]
        // GET: Gets all the employees
        public IActionResult GetEmployees()
        {
            List<Employee> result = new List<Employee>();
            try
            {
                result = manager.GetEmployees().ToList();
                ResponseData<List<Employee>> response = new ResponseData<List<Employee>>();
                response.Content = result;
                response.Code = 200;
                response.IsSuccessful = true;
                var httpResult = this.Ok(response);
                return httpResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ResponseData<List<Employee>> response = new ResponseData<List<Employee>>();
                response.Content = null;
                response.Code = 400;
                response.IsSuccessful = false;
                var httpResult = this.Ok(response);
                return httpResult;
            }

        }


        [HttpPost, AllowAnonymous, Route("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody] NewEmployeeForm req)
        {
            var res = new BaseResponse();
            try
            {
                var createdUser = manager.CreateEmployee(req.NewEmployee);
                if (createdUser)
                {

                    res.Code = 200;
                    res.IsSuccessful = true;
                    return Ok(res);
                }


                res.Code = 401;
                res.IsSuccessful = false;
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

