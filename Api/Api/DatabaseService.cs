﻿using System;
using System.Collections.Generic;
using Api.Interfaces;
using Api.Models;
using Client.Enums;
using Client.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Api
{
     class DatabaseService : IDatabaseService
    {
        private readonly IMongoCollection<Aircraft> aircrafts;
        private readonly IMongoCollection<Team> teams;
        private readonly IMongoCollection<Employee> employees;
        private readonly IMongoCollection<TaskClass> tasks;
        private readonly IMongoCollection<User> users;



        public DatabaseService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("AirportManagementDb"));
            var database = client.GetDatabase("airport-management-db");
            this.aircrafts = database.GetCollection<Aircraft>("Aircrafts");
            this.teams = database.GetCollection<Team>("Teams");
            this.employees = database.GetCollection<Employee>("Employees");
            this.tasks = database.GetCollection<TaskClass>("Tasks");
            this.users = database.GetCollection<User>("Users");
        }

   
        public Aircraft CreateAircraft(Aircraft aircraft)
        {
            try
            {
               
                aircrafts.InsertOne(aircraft);
                return aircraft;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Team CreateTeam(Team team)
        {
            try
            {

                teams.InsertOne(team);
                return team;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public User CreateUser(User user)
        {
            try
            {

                users.InsertOne(user);
                return user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public TaskClass CreateTask(string aircraftId, string title, string status, string description)
        {
            try
            {
                var task = new TaskClass();
                task.AircraftId = aircraftId;
                task.Title = title;
                task.Status = ServiceTaskStatusesEnum.StatusAssigned;
                task.Description = description;
                tasks.InsertOne(task);
                return task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool AssignTeamToAircraft(string aircraftId, string teamId)
        {
            try
            {
                var updateDef = Builders<Aircraft>.Update.Set(aircraft => aircraft.TeamId, teamId);
                Console.WriteLine("updateDef is ", updateDef);
                var dbResult = this.aircrafts.FindOneAndUpdate(aircraft => aircraft.Id == aircraftId, updateDef);
                Console.WriteLine("dbResult is ", dbResult);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public Employee CreateEmployee(Employee employee)
        {
            try
            {
                employees.InsertOne(employee);
                return employee;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        public IEnumerable<Aircraft> GetAircrafts()
        {
            try
            {
                var dbResult = this.aircrafts.Find(aircraft => true).ToEnumerable();
                var normalizedList = new List<Aircraft>();
                foreach(Aircraft aircraft in dbResult)
                
                {
                    var aircraftTeam = this.teams.Find(team => team.Id == aircraft.TeamId).FirstOrDefault() as Team;
                    var aircraftTasks = this.tasks.Find(task => task.AircraftId == aircraft.Id).ToList();
                    aircraft.Tasks = aircraftTasks;
                    aircraft.TeamName = aircraftTeam.Name;
                    normalizedList.Add(aircraft);
                }
                return normalizedList;

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //implementing GetTeams method - Vlad Andreescu
        public IEnumerable<Team> GetTeams()
        {
            try
            {
                var dbResult = this.teams.Find(teams => true).ToEnumerable();
                return dbResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                var dbResult = this.employees.Find(employee => true).ToEnumerable();
                return dbResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public IEnumerable<TaskClass> GetTasksForAircraft(string aircraftId)
        {
            try
            {
                var dbResult = this.tasks.Find(task => task.AircraftId==aircraftId).ToEnumerable();
                return dbResult;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //implementing GetTeamMembers method - Vlad Andreescu
        public IEnumerable<Employee> GetTeamMembers(string teamId)
        {
            try
            {
                var dbResult = this.employees.Find(employee => employee.Team == teamId).ToEnumerable();
                Console.WriteLine(dbResult);
                return dbResult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public User GetUser(string password)
        {
            try
            {
                var dbResult = this.users.Find(user => user.Password == password).FirstOrDefault();
                if (dbResult != null)
                {
                    return dbResult;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public bool MarkTaskAsCompleted(string taskId)
        {
            try
            {
                var updateDef = Builders<TaskClass>.Update.Set(task=>task.Status,ServiceTaskStatusesEnum.StatusCompleted);
                var dbResult = this.tasks.FindOneAndUpdate(task=>task.Id==taskId, updateDef);
                if (dbResult != null)
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

        public bool AssignEmployeeToTeam(List<Employee> newEmployees, string teamId)
        {
            try
            {
                foreach (Employee employee in newEmployees)
                {
                    var updateDef = Builders<Employee>.Update.Set(currentEmployee => currentEmployee.Team, teamId.Trim());
                    var dbResult = this.employees.FindOneAndUpdate(foundEmployee => foundEmployee.Id == employee.Id.Trim(), updateDef);
                    Console.WriteLine("dbResult is ", dbResult);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}