using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface ITaskManager
    {
        bool CreateTask(string AircraftId, string Title, string Status, string Description);

        bool MarkTaskAsCompleted(string taskId, string status);
    }
}
