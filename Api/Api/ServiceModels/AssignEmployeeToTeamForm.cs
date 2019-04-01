using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModels
{
    using Client.Models;

    public class AssignEmployeeToTeamForm
    {
        public string TeamId { get; set; }

        public List<Employee> newEmployees { get; set; }
    }
}