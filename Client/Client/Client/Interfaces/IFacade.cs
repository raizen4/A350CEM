using Client.Models;
using Client.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Interfaces
{
    public interface IFacade
    {
        ResponseData<Team> GetTeams();

        ResponseData<Employee> GetEmployees();
        ResponseData<Task> GetTasks();



    }
}
