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
        Task<ResponseData<IEnumerable<Employee>>> GetTeamMembers(string teamId);

        Task<ResponseBase> AddMemberToTeam(List<Employee> newEmployees, string teamId);

        Task<ResponseBase> AssignTeamToAircraft(string aircraftId, string teamId);
        //Tasks methods
        Task<ResponseBase> CreateTask(string aircraftId, string teamId, string description);
        Task<ResponseData<IEnumerable<ServiceTask>>> GetTasksForAircraft(string aircraftId);
        Task<ResponseBase> AssignTaskToAircraft(string aircraftId, string title, string description, string status);
       
        //Authenticate methods
        Task<ResponseData<User>> Login(string password);
        Task<ResponseBase> MarkTaskAsCompleted(string taskToBeCompleted);


    }
}
