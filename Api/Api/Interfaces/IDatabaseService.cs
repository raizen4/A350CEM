using Api.Models;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Client.Models.Task;

namespace Api.Interfaces
{
    public interface IDatabaseService
    {
        User GetUser(string password);
        User CreateUser(User user);

<<<<<<< HEAD
        Team CreateTeam(Team team);
=======
        IEnumerable<Aircraft> GetAircrafts();
        IEnumerable<Team> GetTeams();
>>>>>>> implemented GetTeams and getTeamMembers in IDatabaseService

        Employee CreateEmployee(Employee employee);
        bool AssignEmployeeToTeam(string employeeId, string teamId);
        IEnumerable<Employee> GetEmployees();

<<<<<<< HEAD
        Aircraft CreateAircraft(Aircraft aircraft);
=======
        IEnumerable<Client.Models.Task> GetTasksForAircraft(string aircraftId);
        IEnumerable<Team> GetTeamMembers(string teamId);
>>>>>>> implemented GetTeams and getTeamMembers in IDatabaseService
        bool MarkTaskAsCompleted(string taskId);
        IEnumerable<Aircraft> GetAircrafts();
        IEnumerable<Task> GetTasksForAircraft(string aircraftId);

        Task CreateTask(Task task);
    }
}
