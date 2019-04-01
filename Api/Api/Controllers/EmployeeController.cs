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
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// The Employee Manager
        /// </summary>
        private readonly IEmployeeManager manager;



        public EmployeeController(IEmployeeManager manager)
        {
            this.manager = manager;
        }


        [HttpGet, AllowAnonymous, Route("GetEmployees")]
        // GET: Gets all the employees
        public IActionResult GetEmployees()
        {
            List<Employee> result = new List<Employee>();
            try
            {
                // Assign the entire data to a list and return 200
                result = manager.GetEmployees().ToList();
                ResponseData<List<Employee>> response = new ResponseData<List<Employee>>();
                response.Content = result;
                response.Code = 200;
                response.HasBeenSuccessful = true;
                var httpResult = this.Ok(response);
                return httpResult;

            }
            catch (Exception e)
            {
                // Return 400, something went wrong
                Console.WriteLine(e.Message);
                ResponseData<List<Employee>> response = new ResponseData<List<Employee>>();
                response.Content = null;
                response.Code = 400;
                response.HasBeenSuccessful = false;
                var httpResult = this.Ok(response);
                return httpResult;
            }

        }


        [HttpPost, AllowAnonymous, Route("CreateEmployee")]
        public IActionResult CreateEmployee([FromBody] NewEmployeeForm employeeForm)
        {
            // Create a new employee Form 
            var employee = employeeForm.NewEmployee;
            var res = new BaseResponse();
            try
            {
                // Send the employee body to the manager
                var createdUser = manager.CreateEmployee(employeeForm.NewEmployee);
                if (createdUser)
                {
                    // Send a 200 back + the full employee data
                    res.Code = 200;
                    res.HasBeenSuccessful = true;
                    return Ok(res);
                }
                // Send a 401, something went wrong
                res.Code = 401;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }
            catch (Exception e)
            {
                // Send a 501, something went wrong internally
                Console.WriteLine(e.Message);
                res.Code = 501;
                res.HasBeenSuccessful = false;
                
                return Ok(res);
            }
        }

        [HttpPut, AllowAnonymous, Route("AssignEmployeeToTeam")]
        public IActionResult AssignEmployeeToTeam([FromBody]AssignEmployeeToTeamForm assignEmployeeForm)
        {
            var response = new BaseResponse()
            {
                HasBeenSuccessful = false
            };

            try
            {
                var result = manager.AssignEmployeeToTeam(assignEmployeeForm.newEmployees, assignEmployeeForm.TeamId);
                if (result)
                {
                    response.HasBeenSuccessful = true;
                    response.Code = 200;
                    return this.Ok(response);
                }

                response.HasBeenSuccessful = false;
                response.Code = 501;
                return this.Ok(response);
            }
            catch (Exception e)
            {
                response.HasBeenSuccessful = false;
                response.Code = 501;
                return this.Ok(response);
            }

        }

    }
}

