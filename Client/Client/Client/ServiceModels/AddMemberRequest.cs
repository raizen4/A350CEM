using System;
using System.Collections.Generic;
using System.Text;

namespace Client.ServiceModels
{
    class AddMemberRequest
    {
        public string EmployeeId { get; set; }

        public string TeamId { get; set; }
    }
}
