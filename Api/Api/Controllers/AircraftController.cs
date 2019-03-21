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

        [HttpPost, Authorize, Route("CreateAircraft")]
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

        [HttpGet, Authorize, Route("GetAircrafts")]
        // GET: Gets all the employees
        public IActionResult GetAircrafts()
        {
            List<Aircraft> result = new List<Aircraft>();
            try
            {
                result = manager.GetAircrafts().ToList();
                ResponseData<List<Aircraft>> response = new ResponseData<List<Aircraft>>();
                response.Content = result;
                response.Code = 200;
                response.IsSuccessful = true;
                var httpResult = this.Ok(response);
                return httpResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ResponseData<List<Aircraft>> response = new ResponseData<List<Aircraft>>();
                response.Content = null;
                response.Code = 400;
                response.IsSuccessful = false;
                var httpResult = this.Ok(response);
                return httpResult;
            }

        }


    }
}