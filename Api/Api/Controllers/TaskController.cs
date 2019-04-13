using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        /// <summary>
        /// The manager responsible for tasks
        /// </summary>
        private readonly ITaskManager manager;

        public TaskController(ITaskManager manager)
        {
            this.manager = manager;
        }

        // Create a new Task Request
        [HttpPost, AllowAnonymous, Route("CreateTask")]
        public IActionResult CreateTask([FromBody] NewTaskForm taskForm)
        {
            // Assign the data from body to variables
            var aircraftId = taskForm.AircraftId;
            var title = taskForm.Title;
            var status = taskForm.Staus;
            var description = taskForm.Description;
            // Create a new response body
            var res = new BaseResponse();
            try
            {
                // Send the varisbles to the Task Manager to create a new Task
                var createdTask = manager.CreateTask(aircraftId, title, status, description);
                if (createdTask)
                {
                    // Respond with a 200 + the task body
                    res.Code = 200;
                    res.HasBeenSuccessful = true;
                    return Ok(res);
                }
                // Repond with 401, something went wrong
                res.Code = 401;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }
            catch (Exception e)
            {
                // Repond with 501, something went wrong internally
                res.Code = 501;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }
        }
    }
}