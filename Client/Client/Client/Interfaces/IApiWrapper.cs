using Client.Models;
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
        Task<HttpResponseMessage> Login(string password);

        Task<HttpResponseMessage> GetEmployees();

        Task<HttpResponseMessage> GetAircrafts();

        Task<HttpResponseMessage> GetTeams();

        Task<HttpResponseMessage> GetMembers();

        Task<HttpResponseMessage> GetTasks();
    }
}
