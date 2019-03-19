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
        [Post("/Api/Login/Login")]
        // Task<HttpResponseMessage> Login(string password);
        Task<HttpResponseMessage> Login([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Json)] string body);

        // Employees endpoint
        [Get("/Api/Employee/GetEmployees")]
        Task<HttpResponseMessage> GetEmployees();

        // Aircraft endpoint
        [Get("/Api/Aircraft/GetAricrafts")]
        Task<HttpResponseMessage> GetAircrafts();

        // Teams endpoint
        [Get("/Api/Team/GetTeams")]
        Task<HttpResponseMessage> GetTeams();
        [Post("/Api/Team/GetTeam")]
        // Task<HttpResponseMessage> GetTeam(string teamId);
        Task<HttpResponseMessage> GetTeam([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Json)] string body);
        [Post("/Api/Team/GetMembers")]
        // Task<HttpResponseMessage> GetMembers(string teamId);
        Task<HttpResponseMessage> GetMembers([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Json)] string body);
        [Post("/Api/Team/AddMemberToTeam")]
        // Task<HttpResponseMessage> AddMemberToTeam(string teamId);
        Task<HttpResponseMessage> AddMemberToTeam([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Json)] string body);

        // Tasks endpoint
        [Post("/Api/Task/CreateTask")]
        // Task<HttpResponseMessage> CreateTask(string aircraftId, string teamId, string description);
        Task<HttpResponseMessage> CreateTask([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Json)] string body);
        [Post("/Api/Task/GetTasksForAircraft")]
        // Task<HttpResponseMessage> GetTasksForAircraft(string aircraftId);
        Task<HttpResponseMessage> GetTasksForAircraft([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Json)] string body);

    }
}
