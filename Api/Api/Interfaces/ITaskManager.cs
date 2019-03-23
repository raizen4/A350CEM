using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    interface ITaskManager
    {
       

        bool MarkTaskAsCompleted(string taskId, string status);

        Task CreateTask(Task task);

    }
}
