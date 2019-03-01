using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    interface IApiEndpoints
    {
        // Login endpoint
        [Get("/Api/Login/Login")]
        Task<HttpResponseMessage> Login(string password);

        // Employees endpoint
        [Get("/Api/Employee/GetEmployees")]
        Task<HttpResponseMessage> GetEmployees();

        // Aircraft endpoint
        [Get("/Api/Aircraft/GetAricrafts")]
        Task<HttpResponseMessage> GetAircrafts();

        // Teams endpoint
        [Get("/Api/Team/GetTeams")]
        Task<HttpResponseMessage> GetTeams();
        [Get("/Api/Team/GetTeam")]
        Task<HttpResponseMessage> GetTeam(string teamId);
        [Get("/Api/Team/GetMembers")]
        Task<HttpResponseMessage> GetMembers(string teamId);
        [Get("/Api/Team/AddMemberToTeam")]
        Task<HttpResponseMessage> AddMemberToTeam(string teamId);

        // Tasks endpoint
        [Get("/Api/Task/CreateTask")]
        Task<HttpResponseMessage> CreateTask(string aircraftId, string teamId, string description);
        [Get("/Api/Task/GetTasksForAircraft")]
        Task<HttpResponseMessage> GetTasksForAircraft(string aircraftId);

    }
}
