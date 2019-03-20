using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.ServiceModels;
using Client.Models;
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

        /// <summary>
        /// Initialises a new instance of the <see cref="SummaryChangingRoomController"/> class.
        /// </summary>
        /// <param name="manager">The manager.</param>

        public EmployeeController(IEmployeeManager manager)
        {
            this.manager = manager;
        }


        [HttpGet]
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
    }
}

