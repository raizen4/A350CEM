using System.Collections.Generic;
using Api.Interfaces;
using Api.Models;
using Client.Models;

namespace Api
{
    internal class DatabaseService : IDatabaseService
    {
        public bool CreateAircraft(Aircraft aircraft)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateTeam(Team team)
        {
            throw new System.NotImplementedException();
        }

        public bool CreateUser(Employee user)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Aircraft> GetAircrafts()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Task> GetTasksForAircraft(string aircraftId)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(string password)
        {
            throw new System.NotImplementedException();
        }
    }
}