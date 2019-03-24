using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Interfaces
{
    public interface ICreateTaskManager
    {
        bool CreateTask(Task newTask);
    }
}
