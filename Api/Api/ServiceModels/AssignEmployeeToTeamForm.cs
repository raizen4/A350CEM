using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModels
{
    public class AssignEmployeeToTeamForm
    {
        public string TeamId { get; set; }

        public string EmployeeId { get; set; }
    }
}