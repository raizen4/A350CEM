using System;
using System.Collections.Generic;
using Api.Interfaces;
using Api.ServiceModels;
using Client.Models;

namespace Api.Managers
{
    internal class AircraftManager : IAircraftManager
    {
        private readonly IDatabaseService dbService;
        public AircraftManager(IDatabaseService dbService)
        {
            this.dbService = dbService;
        }
        public bool CreateAircraft(Aircraft newAircraft)
        {
        
            try
            {
                var result = dbService.CreateAircraft(newAircraft);
                if (result!=null)
                {
                    return true;
                }
                return false;
            }
            catch(Exception e)
            {
                
                Console.WriteLine(e.Message);
                return false;
            }
        }
            
        public bool MarkTaskAsCompleted(string taskId)
        {
            try
            {
                var result = dbService.MarkTaskAsCompleted(taskId);
                if (result)
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
        public IEnumerable<Aircraft> GetAircrafts()
        {
            try
            {
                var result = dbService.GetAircrafts();
                if (result!=null)
                {
                    return result;
                }
                return new List<Aircraft>();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }

        public IEnumerable<Task> GetTasksForAircraft(string AircraftId)
        {
            try
            {
                var result = dbService.GetTasksForAircraft(AircraftId);
                if (result != null)
                {
                    return result;
                }
                return new List<Task>();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}