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
    // Employee Manager
    public class EmployeeManager : IEmployeeManager
    {
        private AppSettings settings;
        private readonly IDatabaseService dbService;
        public EmployeeManager(IOptions<AppSettings> appSettings, IDatabaseService dbService)
        {
            this.settings = appSettings.Value;
            this.dbService = dbService;
        }

        // Create a new Employee Manager
        public bool CreateEmployee(Employee newEmployee)
        {

            try
            {
                // Request DB connection to create a new Employee
                var result = dbService.CreateEmployee(newEmployee);
                if (result != null)
                {
                    // Return success
                    return true;
                }
                // Return fail
                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

<<<<<<< HEAD
        public bool AssignEmployeeToTeam(List<Employee> newEmployees ,string teamId)
        {
            try
            {
                var result = dbService.AssignEmployeeToTeam(newEmployees, teamId);
=======
        // Assign an Employee to a Team Manager
        public bool AssignEmployeeToTeam(string employeeId ,string teamId)
        {
            try
            {
                // Request DB connection to assign an Employee to a Team
                var result = dbService.AssignEmployeeToTeam(employeeId, teamId);
>>>>>>> b837f944de513d6e2f6a98e9b32dda34716c915e
                if (result)
                {
                    // Return success
                    return true;
                }
                // Return fail
                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        // Get all Employees Manager
        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                // Request DB connection to get Employees
                var result = dbService.GetEmployees();
                if (result != null)
                {
                    // Return success - the entire list
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
