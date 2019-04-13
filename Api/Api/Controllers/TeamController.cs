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
        /// <summary>
        /// The Team Manager
        /// </summary>
        private readonly ITeamManager manager;

        public TeamController(ITeamManager manager)
        {
            this.manager = manager;
        }

        // Create a new Team
        [HttpPost, AllowAnonymous, Route("CreateTeam")]
        public IActionResult CreateTeam([FromBody] NewTeamForm teamForm)
        {
            // Create a new Team Request body
            var team = teamForm.NewTeam;
            var res = new BaseResponse();
            try
            {
                // Send the request to the Team Manager
                var createdTeam = manager.CreateTeam(teamForm.NewTeam);
                if (createdTeam)
                {
                    // Respond with a 200 + the team body
                    res.Code = 200;
                    res.HasBeenSuccessful = true;
                    return Ok(res);
                }
                // Reponse with 401, something went wrong
                res.Code = 401;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }
            catch (Exception e)
            {
                // Reponse with 501, something went wrong internally
                res.Code = 501;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }
        }

        // Assign a Team to an Aircraft
        [HttpPut, AllowAnonymous, Route("AssignTeamToAircraft")]
        public IActionResult AssignTeamToAircraft([FromBody] AssignTeamToAircraft form)
        {
            // Assign the body request to the suitable variables
            var aircraftId = form.AircraftId;
            var teamId = form.TeamId;
            var res = new BaseResponse();
            try
            {
                // Send the variables to the Manager
                var createdTask = manager.AssignTeamToAircraft(aircraftId, teamId);
                if (createdTask)
                {
                    // Respond with a 200 - success
                    res.Code = 200;
                    res.HasBeenSuccessful = true;
                    return Ok(res);
                }
                // Respond with a 401, something went wrong
                res.Code = 401;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                // Respond with a 401, something went wrong internally
                res.Code = 501;
                res.HasBeenSuccessful = false;
                return Ok(res);
            }
        }

        [HttpGet, AllowAnonymous, Route("GetTeams")]
        // GET: Gets all teams
        public IActionResult GetTeams()
        {
            // Create a new list
            List<Team> result = new List<Team>();
            try
            {
                // Respond with a 200 - success. Return the list with all the teams
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
                // Respond with a 400, something went wrong
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
                // Respond with a 200 - success
                var teamId = req.teamId;
                // teamId is the team id we are searching the members for
                result = manager.GetTeamMembers(teamId).ToList();
                ResponseData<List<Employee>> response = new ResponseData<List<Employee>>();
                response.Content = result;
                response.Code = 200;
                response.HasBeenSuccessful = true;
                // Return the populated list
                var httpResult = this.Ok(response);
                return httpResult;
            }
            catch(Exception e)
            {
                // Respond with a 401, something went wrong
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