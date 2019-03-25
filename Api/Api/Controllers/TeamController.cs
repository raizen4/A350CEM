using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Interfaces;
using Api.ServiceModels;
using Client.Models;
using Client.ServiceModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamManager manager;
        public TeamController(ITeamManager manager)
        {
            this.manager = manager;
        }

        [HttpPost, AllowAnonymous, Route("CreateTeam")]
        public IActionResult CreateTeam([FromBody] NewTeamForm teamForm)
        {
            var team = teamForm.NewTeam;
            var res = new BaseResponse();
            try
            {
                var createdTeam = manager.CreateTeam(teamForm.NewTeam);
                if (createdTeam)
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

        [HttpPost, AllowAnonymous, Route("AssignTeamToAircraft")]
        public IActionResult AssignTeamToAircraft([FromBody] AssignTeamToAircraft form)
        {
            var aircraftId = form.AircraftId;
            var teamId = form.TeamId;

            var res = new BaseResponse();
            try
            {
                var createdTask = manager.AssignTeamToAircraft(aircraftId, teamId);
                if (createdTask)
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
                Console.WriteLine(e.Message);

                res.Code = 501;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }
        }

        [HttpGet, AllowAnonymous, Route("GetTeams")]
        // GET: Gets all teams
        public IActionResult GetTeams()
        {
            List<Team> result = new List<Team>();
            try
            {
                result = manager.GetTeams().ToList();
                ResponseData<List<Team>> response = new ResponseData<List<Team>>();
                response.Content = result;
                response.Code = 200;
                response.HasBeenSuccessful = true;
                var httpResult = this.Ok(response);
                return httpResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ResponseData<List<Team>> response = new ResponseData<List<Team>>();
                response.Content = null;
                response.Code = 400;
                response.HasBeenSuccessful = false;
                var httpResult = this.Ok(response);
                return httpResult;
            }
        }
        [HttpPost, AllowAnonymous, Route("GetTeamMembers")]
        //GET: Gets all team members
        public IActionResult GetTeamMembers([FromBody] GetTeamMembersRequest req)
        {
            List<Employee> result = new List<Employee>();
            try
            {
                var teamId = req.teamId;
                result = manager.GetTeamMembers(teamId).ToList();
                ResponseData<List<Employee>> response = new ResponseData<List<Employee>>();
                response.Content = result;
                response.Code = 200;
                response.HasBeenSuccessful = true;
                var httpResult = this.Ok(response);
                return httpResult;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                ResponseData<List<Employee>> response = new ResponseData<List<Employee>>();
                response.Content = null;
                response.Code = 400;
                response.HasBeenSuccessful = false;
                var httpResult = this.Ok(response);
                return httpResult;
            }
        }
    }
}