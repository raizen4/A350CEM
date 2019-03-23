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

        public bool CreateEmployee(Employee newEmployee)
        {

            try
            {
                var result = dbService.CreateEmployee(newEmployee);
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool AssignEmployeeToTeam(string employeeId ,string teamId)
        {
            try
            {
                var result = dbService.AssignEmployeeToTeam(employeeId, teamId);
                if (result)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                var result = dbService.GetEmployees();
                if (result != null)
                {
                    return result;
                }
                return new List<Employee>();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }


    }
}
