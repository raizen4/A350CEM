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
                response.IsSuccessful = true;
                var httpResult = this.Ok(response);
                return httpResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                ResponseData<List<Team>> response = new ResponseData<List<Team>>();
                response.Content = null;
                response.Code = 400;
                response.IsSuccessful = false;
                var httpResult = this.Ok(response);
                return httpResult;
            }
        }
        [HttpGet, AllowAnonymous, Route("GetTeamMembers/{teamId}")]
        //GET: Gets all team members
        public IActionResult GetTeamMembers(string teamId)
        {
            List<Employee> result = new List<Employee>();
            try
            {
                result = manager.GetTeamMembers(teamId).ToList();
                ResponseData<List<Employee>> response = new ResponseData<List<Employee>>();
                response.Content = result;
                response.Code = 200;
                response.IsSuccessful = true;
                var httpResult = this.Ok(response);
                return httpResult;
            }
            catch(Exception e)
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