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

        bool CreateUser(Employee user);
        bool CreateAircraft(Aircraft aircraft);
        bool CreateTeam(Team team);

        IEnumerable<Aircraft> GetAircrafts();

        IEnumerable<Employee> GetEmployees();

        IEnumerable<Client.Models.Task> GetTasksForAircraft(string aircraftId);
    }
}
