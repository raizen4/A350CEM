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
        public bool CreateAircraft(NewAircraftForm aircraftForm)
        {
            var aircraftToBeInserted = aircraftForm.NewAircraft;
            
            try
            {
                var result = dbService.CreateAircraft(aircraftToBeInserted);
                if (result)
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
    }
}