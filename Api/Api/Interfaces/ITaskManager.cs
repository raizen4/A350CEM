using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    interface ITaskManager
    {
        bool CreateTask(string description, string teamId, string aircraftId);
       

        bool ChangeStatusForTask(string taskId);


    }
}
