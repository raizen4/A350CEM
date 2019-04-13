using System;
using System.Collections.Generic;
using System.Text;

namespace Client.ServiceModels
{
    public class AssignTaskRequest
    {
        public string AircraftId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}