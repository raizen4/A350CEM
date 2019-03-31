using Api.Models;
using Api.ServiceModels;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
   public interface IEmployeeManager
    {
        bool AssignEmployeeToTeam(string employeeId, string teamId);

        bool CreateEmployee(Employee newEmployee);

        IEnumerable<Employee> GetEmployees();
    }
}
