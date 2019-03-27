using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.ServiceModels;
using Client.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftManager manager;
            public AircraftController(IAircraftManager manager)
        {
            this.manager = manager;
        }

        [HttpPost,AllowAnonymous, Route("CreateAircraft")]
        public IActionResult CreateAircraft([FromBody] NewAircraftForm aircraftForm)
        {
            var aircraft = aircraftForm.NewAircraft;
            var res = new BaseResponse();
            try
            {
                var createdAircraft = manager.CreateAircraft(aircraftForm.NewAircraft);
                if (createdAircraft)
                {

                    res.Code = 200;
                    res.HasBeenSuccessful = true;
                    return Ok(res);
                }


                res.Code = 501;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }
            catch (Exception e)
            {

                res.Code = 501;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }

        }

        [HttpGet, AllowAnonymous, Route("GetAircrafts")]
        public IActionResult GetAircrafts()
        {
            List<Aircraft> result = new List<Aircraft>();
            try
            {
                result = manager.GetAircrafts().ToList();
                ResponseData<List<Aircraft>> response = new ResponseData<List<Aircraft>>();
                response.Content = result;
                response.Code = 200;
                response.HasBeenSuccessful = true;
                var httpResult = this.Ok(response);
                return httpResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ResponseData<List<Aircraft>> response = new ResponseData<List<Aircraft>>();
                response.Content = null;
                response.Code = 400;
                response.HasBeenSuccessful = false;
                var httpResult = this.Ok(response);
                return httpResult;
            }

        }

        [HttpPost, AllowAnonymous, Route("GetTasksForAircraft")]
        public IActionResult GetTasksForAircraft([FromBody]RequireTasksForAircraftForm form)
        {
            List<TaskClass> result = new List<TaskClass>();
            try
            {
                result = manager.GetTasksForAircraft(form.AircraftId).ToList();
                ResponseData<List<TaskClass>> response = new ResponseData<List<TaskClass>>();
                response.Content = result;
                response.Code = 200;
                response.HasBeenSuccessful = true;
                var httpResult = this.Ok(response);
                return httpResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ResponseData<List<TaskClass>> response = new ResponseData<List<TaskClass>>();
                response.Content = null;
                response.Code = 400;
                response.HasBeenSuccessful = false;
                var httpResult = this.Ok(response);
                return httpResult;
            }

        }


        [HttpPut, Authorize, Route("MarkTaskAsCompleted")]

        public IActionResult MarkTaskAsCompleted([FromBody]MarkTaskRequest req)
        {
            var response = new BaseResponse()
            {
                HasBeenSuccessful = false
            };

            try
            {
                var result = manager.MarkTaskAsCompleted(req.TaskId);
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