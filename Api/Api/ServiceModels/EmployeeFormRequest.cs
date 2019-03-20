using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModels
{
    public class EmployeeFormRequest
    {
        public string Name { get; set; }
        public string Spec { get; set; }

        public string ManHours { get; set; }

        public string TeamId { get; set; }
    }
}
