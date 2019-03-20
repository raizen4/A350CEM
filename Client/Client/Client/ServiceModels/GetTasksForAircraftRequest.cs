using Client.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.ServiceModels
{
    public class GetTasksForAircraftRequest
    {
        public List<Aircraft> GetTasksForAircraft { get; set; }
    }
}
