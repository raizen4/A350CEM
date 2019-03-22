using System;
using System.Collections.Generic;
using Api.Interfaces;
using Api.ServiceModels;
using Client.Models;

namespace Api.Managers
{
    internal class TeamManager : ITeamManager
    {
        private readonly IDatabaseService dbService;
        public TeamManager(IDatabaseService dbService)
        {
            this.dbService = dbService;
        }

        public bool CreateTeam(Team newTeam)
        {
            try
            {
                var result = dbService.CreateTeam(newTeam);
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

        public IEnumerable<Team> GetTeams()
        {
            try
            {
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

        public IEnumerable<Team> GetTeamMembers(string teamId)
        {
            try
            {
                var result = dbService.GetTeamMembers(teamId);
                if (result != null)
                {
                    return result;
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}