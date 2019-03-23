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
    public class CreateTaskController : ControllerBase
    {
        /// <summary>
        /// The manager
        /// </summary>
        private readonly ICreateTaskManager manager;



        public CreateTaskController(ICreateTaskManager manager)
        {
            this.manager = manager;
        }

        [HttpPost, AllowAnonymous, Route("CreateTask")]
        public IActionResult CreateTask([FromBody] NewTaskForm taskForm)
        {
            var task = taskForm.NewTask;
            var res = new BaseResponse();
            try
            {
                var createdTask = manager.CreateTask(taskForm.NewTask);
                if (createdTask)
                {
                    res.Code = 200;
                    res.IsSuccessful = true;
                    return Ok(res);
                }

                res.Code = 501;
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