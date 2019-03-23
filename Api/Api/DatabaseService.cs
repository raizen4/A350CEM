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
        private readonly IMongoCollection<Task> tasks;
        private readonly IMongoCollection<User> users;



        public DatabaseService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("AirportManagementDb"));
            var database = client.GetDatabase("airport-management-db");
            this.aircrafts = database.GetCollection<Aircraft>("Aircrafts");
            this.teams = database.GetCollection<Team>("Teams");
            this.employees = database.GetCollection<Employee>("Employees");
            this.tasks = database.GetCollection<Task>("Tasks");
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

        public Task CreateTask(Task task)
        {
            Console.WriteLine("TAAAAASK", task);
            try
            {
                tasks.InsertOne(task);
                return task;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
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
                return dbResult;

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

        public IEnumerable<Task> GetTasksForAircraft(string aircraftId)
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
        public IEnumerable<Team> GetTeamMembers(string teamId)
        {
            try
            {
                var dbResult = this.teams.Find<Team>(team => team.Id == teamId).ToEnumerable();
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
                var updateDef = Builders<Task>.Update.Set(task=>task.Status,ServiceTaskStatusesEnum.StatusCompleted);
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

        public bool AssignEmployeeToTeam(string employeeId, string teamId)
        {
            try
            {
                var updateDef = Builders<Employee>.Update.Set(employee => employee.TeamId, teamId);
                Console.WriteLine("updateDef is ", updateDef);
                var dbResult = this.employees.FindOneAndUpdate(employee => employee.Id == employeeId, updateDef);
                Console.WriteLine("dbResult is ", dbResult);

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
    }
}