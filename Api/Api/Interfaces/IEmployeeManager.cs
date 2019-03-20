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
        bool AssignEmployeeToTeam(string teamId);

        bool CreateEmployee(EmployeeFormRequest request);
        IEnumerable<Employee> GetEmployees();


        User Authenticate(LoginRequest loginReq);
    }
}
