using System;
using System.Collections.Generic;
using Api.Interfaces;
using Api.ServiceModels;
using Client.Models;

namespace Api.Managers
{
    // Team Manager
    internal class TeamManager : ITeamManager
    {
        private readonly IDatabaseService dbService;
        public TeamManager(IDatabaseService dbService)
        {
            this.dbService = dbService;
        }

        // Create Team manager
        public bool CreateTeam(Team newTeam)
        {
            try
            {
                // Request DB connection to Create a new Team
                var result = dbService.CreateTeam(newTeam);
                if (result != null)
                {
                    // return success
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

        // Assign a Team to an Aircraft Manager
        public bool AssignTeamToAircraft(string aircraftId, string teamId)
        {
            try
            {
                // Request DB Connection to assign a Team to an Aircraft
                var result = dbService.AssignTeamToAircraft(aircraftId, teamId);
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

        // Get Teams Manager
        public IEnumerable<Team> GetTeams()
        {
            try
            {
                // Request DB Connection to return a list with All The Teams
                var result = dbService.GetTeams();
                if (result != null)
                {
                    return result;
                }
                return new List<Team>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        // Get all the Members for a team ID Manager
        public IEnumerable<Employee> GetTeamMembers(string teamId)
        {
            try
            {
                // Request DB Connection to return a list with All The Members of a Team
                var result = dbService.GetTeamMembers(teamId);
                if (result != null)
                {
                    return result;
                }
                return new List<Employee>();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}