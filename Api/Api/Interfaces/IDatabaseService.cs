using Api.Models;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IDatabaseService
    {
        User GetUser(string password);

        User CreateUser(User user);
        Aircraft CreateAircraft(Aircraft aircraft);
        Team CreateTeam(Team team);

        IEnumerable<Aircraft> GetAircrafts();

        IEnumerable<Employee> GetEmployees();

        IEnumerable<Client.Models.Task> GetTasksForAircraft(string aircraftId);
        bool MarkTaskAsCompleted(string taskId);
    }
}
