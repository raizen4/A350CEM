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

        // Authenticate
        Task<HttpResponseMessage> Login(LoginRequest req);

        // Employees
        Task<HttpResponseMessage> GetEmployees();

        // Aircraft
        Task<HttpResponseMessage> GetAircrafts();

        // Team
        Task<HttpResponseMessage> GetTeams();
        Task<HttpResponseMessage> GetTeam(GetTeamRequest req);
        Task<HttpResponseMessage> GetTeamMembers(GetTeamMembersRequest req);
        Task<HttpResponseMessage> AddMemberToTeam(AddMemberRequest req);
        Task<HttpResponseMessage> MarkTaskAsCompleted(TaskRequest req);


        // Task
        Task<HttpResponseMessage> CreateTask(CreateTaskRequest req);
        Task<HttpResponseMessage> GetTasksForAircraft(GetTasksForAircraftRequest req);
    }
}
