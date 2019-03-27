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
        // Authenticate endpoint
        [Post("/api/User/Authenticate")]
        Task<HttpResponseMessage> Authenticate([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] StringContent body);

        // Employees endpoint
        [Get("/api/Employee/GetEmployees")]
        Task<HttpResponseMessage> GetEmployees();

        [Put("/api/Aircraft/MarkTaskAsCompleted")]
        Task<HttpResponseMessage> MarkTaskAsCompleted([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] StringContent body);

        [Put("/api/Task/AssignTaskToAircraft")]
        Task<HttpResponseMessage> AssignTaskToAircraft([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] StringContent body);
        [Put("/api/Team/AssignTeamToAircraft")]
        Task<HttpResponseMessage> AssignTeamToAircraft([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] StringContent body);

        // Aircraft endpoint
        [Get("/api/Aircraft/GetAircrafts")]
        Task<HttpResponseMessage> GetAircrafts();

        // Teams endpoint
        [Get("/api/Team/GetTeams")]
        Task<HttpResponseMessage> GetTeams();
        [Post("/api/Team/GetTeam")]
        // Task<HttpResponseMessage> GetTeam(string teamId);
        Task<HttpResponseMessage> GetTeam([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] StringContent body);
        [Post("/api/Team/GetTeamMembers")]
        // Task<HttpResponseMessage> GetTeamMembers(string teamId);
        Task<HttpResponseMessage> GetTeamMembers([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] StringContent body);
        [Put("/api/Team/AddMemberToTeam")]
        // Task<HttpResponseMessage> AddMemberToTeam(string teamId);
        Task<HttpResponseMessage> AddMemberToTeam([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] StringContent body);

        // Tasks endpoint
        [Post("/api/Task/CreateTask")]
        // Task<HttpResponseMessage> CreateTask(string aircraftId, string teamId, string description);
        Task<HttpResponseMessage> CreateTask([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] StringContent body);
        [Post("/api/Aircraft/GetTasksForAircraft")]
        // Task<HttpResponseMessage> GetTasksForAircraft(string aircraftId);
        Task<HttpResponseMessage> GetTasksForAircraft([Header("Accept")] string applicationJson, [Body(BodySerializationMethod.Serialized)] StringContent body);
    }
}
