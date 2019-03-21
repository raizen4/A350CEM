using Api.Interfaces;
using Api.Models;
using Api.ServiceModels;
using Client.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Api.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        private AppSettings settings;
        private readonly IDatabaseService dbService;
        public EmployeeManager(IOptions<AppSettings> appSettings, IDatabaseService dbService)
        {
            this.settings = appSettings.Value;
            this.dbService = dbService;
        }
        public bool AssignEmployeeToTeam(string teamId)
        {
            throw new NotImplementedException();
        }


     

        public bool CreateEmployee(Employee newEmployee)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployees()
        {
            throw new NotImplementedException();
        }

       
    }
}
