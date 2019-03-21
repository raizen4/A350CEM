﻿using System;
using System.Collections.Generic;
using Api.Interfaces;
using Api.Models;
using Client.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Api
{
     class DatabaseService : IDatabaseService
    {
        private readonly IMongoCollection<Aircraft> aircrafts;
        private readonly IMongoCollection<Team> teams;

        private readonly IMongoCollection<Employee> employees;
        private readonly IMongoCollection<User> users;



        public DatabaseService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("AirportManagementDb"));
            var database = client.GetDatabase("airport-management-db");
            this.aircrafts = database.GetCollection<Aircraft>("Aircrafts");
            this.teams = database.GetCollection<Team>("Teams");
            this.employees = database.GetCollection<Employee>("Employees");
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

        public IEnumerable<Employee> GetEmployees()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Task> GetTasksForAircraft(string aircraftId)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(string password)
        {
            throw new System.NotImplementedException();
        }
    }
}