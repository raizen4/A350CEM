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
        Task<ResponseData<IEnumerable<Employee>>> GetEmployees();

        //Aircrafts methods
        Task<ResponseData<IEnumerable<Aircraft>>> GetAircrafts();

        //Teams methods
        Task<ResponseData<IEnumerable<Team>>> GetTeams();
        Task<ResponseData<IEnumerable<Team>>> GetTeam(string teamId);
        Task<ResponseData<IEnumerable<Team>>> GetMembers(string teamId);
        Task<ResponseData<IEnumerable<Team>>> AddMemberToTeamAsync(string teamId);

        //Tasks methods
        Task<ResponseBase> CreateTask(string aircraftId, string teamId, string description);
        Task<ResponseData<IEnumerable<ServiceTask>>> GetTasksForAircraft(string aircraftId);
       
        //Login methods
        Task<ResponseBase> Login(string password);


    }
}
