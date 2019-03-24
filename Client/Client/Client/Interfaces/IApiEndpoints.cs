using Client.ServiceModels;
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
        [Post("/api/User/Login")]
        Task<HttpResponseMessage> Login([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] string body);

        // Employees endpoint
        [Get("/api/Employee/GetEmployees")]
        Task<HttpResponseMessage> GetEmployees();

        [Put("/api/Task/MarkTaskAsCompleted")]
        Task<HttpResponseMessage> MarkTaskAsCompleted([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] string body);

        // Aircraft endpoint
        [Get("/api/Aircraft/GetAricrafts")]
        Task<HttpResponseMessage> GetAircrafts();

        // Teams endpoint
        [Get("/api/Team/GetTeams")]
        Task<HttpResponseMessage> GetTeams();
        [Post("/api/Team/GetTeam")]
        // Task<HttpResponseMessage> GetTeam(string teamId);
        Task<HttpResponseMessage> GetTeam([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] string body);
        [Post("/api/Team/GetMembers")]
        // Task<HttpResponseMessage> GetMembers(string teamId);
        Task<HttpResponseMessage> GetMembers([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] string body);
        [Put("/api/Team/AddMemberToTeam")]
        // Task<HttpResponseMessage> AddMemberToTeam(string teamId);
        Task<HttpResponseMessage> AddMemberToTeam([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] string body);

        // Tasks endpoint
        [Post("/api/Task/CreateTask")]
        // Task<HttpResponseMessage> CreateTask(string aircraftId, string teamId, string description);
        Task<HttpResponseMessage> CreateTask([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] string body);
        [Post("/api/Aircraft/GetTasksForAircraft")]
        // Task<HttpResponseMessage> GetTasksForAircraft(string aircraftId);
        Task<HttpResponseMessage> GetTasksForAircraft([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] string body);
    }
}
