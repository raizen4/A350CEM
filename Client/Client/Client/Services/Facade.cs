using Client.Interfaces;
using Client.Models;
using Client.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Services
{
    class Facade : IFacade
    {
        public ResponseData<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public ResponseData<Task> GetTasks()
        {
            throw new NotImplementedException();
        }

        public ResponseData<Team> GetTeams()
        {
            throw new NotImplementedException();
        }
    }
}
