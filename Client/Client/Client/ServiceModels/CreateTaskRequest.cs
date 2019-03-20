using System;
using System.Collections.Generic;
using System.Text;

namespace Client.ServiceModels
{
    public class CreateTaskRequest
    {
        public string AircraftId { get; set; }

        public string TaskId { get; set; }

        public string Description { get; set; }
    }
}
