using System;
using System.Collections.Generic;
using System.Text;

namespace Client.ServiceModels
{
    using Models;

    public class AddMemberRequest
    {
        public List<Employee> NewMembers { get; set; }

        public string TeamId { get; set; }
    }
}
