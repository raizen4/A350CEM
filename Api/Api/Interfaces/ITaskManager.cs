using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Client.Models;
using Task = Client.Models.Task;

namespace Api.Interfaces
{
    public interface ITaskManager
    {
       
        bool MarkTaskAsCompleted(string taskId, string status);

        bool CreateTask(Task newTask);
    }
}
