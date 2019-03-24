using Api.ServiceModels;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface IAircraftManager
    {
        IEnumerable<Aircraft> GetAircrafts();

        bool CreateAircraft(Aircraft newAircraft);

        bool MarkTaskAsCompleted(string taskId);

        IEnumerable<Client.Models.Task> GetTasksForAircraft(string AircraftId);

    }
}
