﻿using Api.Models;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task = Client.Models.TaskClass;

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
        bool AssignEmployeeToTeam(List<Employee> newEmployees, string teamId);

        //Team
        Team CreateTeam(Team team);
        IEnumerable<Team> GetTeams();
        IEnumerable<Employee> GetTeamMembers(string teamId);
        bool AssignTeamToAircraft(string aicraftId, string teamId);


        //Aircraft
        Aircraft CreateAircraft(Aircraft aircraft);
        IEnumerable<TaskClass> GetTasksForAircraft(string aircraftId);
        IEnumerable<Aircraft> GetAircrafts();

        //Task
        TaskClass CreateTask(string aicraftId, string title, string status, string description);
        bool MarkTaskAsCompleted(string taskId);
       
    }
}
