using Client.Models;
using Client.ServiceModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
   public interface IApiWrapper
    {
        void InitialiseApi();

        // Login
        Task<HttpResponseMessage> Login(LoginRequest req);

        // Employees
        Task<HttpResponseMessage> GetEmployees();

        // Aircraft
        Task<HttpResponseMessage> GetAircrafts();

        // Team
        Task<HttpResponseMessage> GetTeams();
        Task<HttpResponseMessage> GetTeam(string teamId);
        Task<HttpResponseMessage> GetMembers(string teamId);
        Task<HttpResponseMessage> AddMemberToTeam(string teamId);

        Task<HttpResponseMessage> MarkTaskAsCompleted(TaskRequest req);


        // Task
        Task<HttpResponseMessage> CreateTask(string aircraftId, string teamId, string description);
        Task<HttpResponseMessage> GetTasksForAircraft(string aircraftId);

    }
}
