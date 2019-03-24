using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface ITaskManager
    {
        bool CreateOneTask(TaskClass newTask);

        bool MarkTaskAsCompleted(string taskId, string status);
    }
}
