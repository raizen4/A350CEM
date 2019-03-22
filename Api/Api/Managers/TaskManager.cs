using Api.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = Client.Models.Task;

namespace Api.Managers
{
    public class TaskManager : ITaskManager
    {
        private readonly IDatabaseService dbService;
        public TaskManager(IDatabaseService dbService)
        {
            this.dbService = dbService;
        }
        public bool CreateTask(Task newTask)
        {

            try
            {
                var result = dbService.CreateTask(newTask);
                if (result != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return false;
            }
        }

        public bool MarkTaskAsCompleted(string taskId, string status)
        {
            throw new NotImplementedException();
        }
    }
}