using Client.Models;
using Client.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    public interface IFacade
    {
        //Employees methods
        Task<ResponseData<Employee>> GetEmployees();

        //Aircrafts methods
        Task<ResponseData<Aircraft>> GetAircrafts();

        //Teams methods
        Task<ResponseData<Team>> GetTeams();
        Task<ResponseData<Team>> GetTeam(string teamId);
        Task<ResponseData<Team>> GetMembers(string teamId);
        Task<ResponseData<Team>> AddMemberToTeam(string teamId);

        //Tasks methods
        Task<ResponseBase> CreateTask(string aircraftId, string teamId, string description);
        Task<ResponseData<ServiceTask>> GetTasksForAircraft(string aircraftId);

        //Login methods
        Task<ResponseBase> Login(string password);


    }
}
