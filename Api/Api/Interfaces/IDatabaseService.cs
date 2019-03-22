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

        Team CreateTeam(Team team);

        Employee CreateEmployee(Employee employee);
        bool AssignEmployeeToTeam(string teamId);
        IEnumerable<Employee> GetEmployees();

        Aircraft CreateAircraft(Aircraft aircraft);
        bool MarkTaskAsCompleted(string taskId);
        IEnumerable<Aircraft> GetAircrafts();
        IEnumerable<Client.Models.Task> GetTasksForAircraft(string aircraftId);

        Task CreateTask(Task task);
    }
}
