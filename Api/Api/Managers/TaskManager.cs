using Api.Interfaces;
using Client.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Managers
{
    public class TaskManager : ITaskManager
    {
        private AppSettings settings;
        private readonly IDatabaseService dbService;
        public TaskManager(IOptions<AppSettings> appSettings, IDatabaseService dbService)
        {
            this.settings = appSettings.Value;
            this.dbService = dbService;
        }

        public bool CreateTask(TaskClass newTask)
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