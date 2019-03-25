using Client.Interfaces;
using Client.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class CreateTeamsPageViewModel : ViewModelBase
    {
        private IFacade _facade;
        private readonly INavigationService _navService;

        public string AircraftId;
        public string TeamId;
        public string Description;

        public List<Aircraft> RealAircrafts;
        public List<Team> RealTeams;

        public DelegateCommand GoToMainPage { get; set; }
        public DelegateCommand AddTeamCommand { get; set; }


        public CreateTeamsPageViewModel(INavigationService navigationService, IFacade facadeImplementation)
            : base(navigationService)
        {
            Title = "Create Teams";
            this._navService = navigationService;
            this.GoToMainPage = new DelegateCommand(async () => await this._navService.NavigateAsync(nameof(Views.MainPage)));
            AddTeamCommand = new DelegateCommand(async () => await AddTeam(AircraftId, TeamId, Description));
            this._facade = facadeImplementation;
        }

        public List<Aircraft> Aircrafts
        {
            get
            {
                return new List<Aircraft>()
                {
                    new Aircraft() {Id="A Id 1"},
                    new Aircraft() {Id="A Id 2"},
                    new Aircraft() {Id="A Id 3"},
                    new Aircraft() {Id="A Id 4"},
                };
            }
        }

        public List<Team> Teams
        {
            get
            {
                return new List<Team>()
                {
                    new Team() {ID="T Id 1"},
                    new Team() {ID="T Id 2"},
                    new Team() {ID="T Id 3"},
                    new Team() {ID="T Id 4"},
                };
            }
        }

        private async Task AddTeam(string AircraftId, string TeamId, string Description)
        {
            try
            {
                var result = await this._facade.AssignTeamToAircraft(AircraftId, TeamId, Description);
                if (result.HasBeenSuccessful)
                {
                    await this._navService.NavigateAsync(nameof(Views.CreateTeamsPage));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }
    }
}
