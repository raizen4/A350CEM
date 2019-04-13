using System;
using System.Collections.Generic;
using System.Text;

namespace Client.ServiceModels
{
    public class AssignTeamRequest
    {
        public string AircraftId { get; set; }

        public string TeamId { get; set; }
    }
}
