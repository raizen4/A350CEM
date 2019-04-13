using Api.Interfaces;
using Client.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Managers
{
    // Task Manager
    public class TaskManager : ITaskManager
    {
        private AppSettings settings;
        private readonly IDatabaseService dbService;
        public TaskManager(IOptions<AppSettings> appSettings, IDatabaseService dbService)
        {
            this.settings = appSettings.Value;
            this.dbService = dbService;
        }

        // Create a new Task Manager
        public bool CreateTask(string aircraftId, string title, string status, string description)
        {
            try
            {
                // Request DB Connection to create a new Task
                var result = dbService.CreateTask(aircraftId, title, status, description);
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

        // Mark Task as completed Manager
        public bool MarkTaskAsCompleted(string taskId, string status)
        {
            throw new NotImplementedException();
        }
    }
}