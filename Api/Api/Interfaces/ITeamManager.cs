using Api.ServiceModels;
using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Interfaces
{
    public interface ITeamManager
    {
        IEnumerable<Team> GetTeams();
        bool CreateTeam(Team newTeam);
        IEnumerable<Employee> GetTeamMembers(string teamId);
        bool AssignTeamToAircraft(string aircraftId, string teamId);

        
    }
}
