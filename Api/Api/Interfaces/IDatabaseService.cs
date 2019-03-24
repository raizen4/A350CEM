﻿using Api.Models;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Client.Models.Task;

namespace Api.Interfaces
{
    public interface IDatabaseService
    {
        //User
        User GetUser(string password);
        User CreateUser(User user);
        //Employee
        Employee CreateEmployee(Employee employee);
        IEnumerable<Employee> GetEmployees();
        bool AssignEmployeeToTeam(string employeeId, string teamId);

        //Team
        Team CreateTeam(Team team);
        IEnumerable<Team> GetTeams();
        IEnumerable<Employee> GetTeamMembers(string teamId);
        //Aircraft
        Aircraft CreateAircraft(Aircraft aircraft);
        IEnumerable<Client.Models.Task> GetTasksForAircraft(string aircraftId);
        IEnumerable<Aircraft> GetAircrafts();

        //Task
        TaskClass CreateTask(TaskClass task);
        bool MarkTaskAsCompleted(string taskId);
       
    }
}
