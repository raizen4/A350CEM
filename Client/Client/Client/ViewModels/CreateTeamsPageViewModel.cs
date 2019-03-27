using Client.Interfaces;
using Client.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class CreateTeamsPageViewModel : ViewModelBase
    {
        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;

<<<<<<< HEAD
        private MarlTaskAsCompleted currentTeam;
=======
        private Team currentTeam;
>>>>>>> ad2f7252bf14a89be1554bcccd425b61cf1fde76
        private Aircraft currentAircraft;

        public DelegateCommand AddTeamCommand { get; set; }

<<<<<<< HEAD
        public MarlTaskAsCompleted CurrentTeam
=======
        public Team CurrentTeam
>>>>>>> ad2f7252bf14a89be1554bcccd425b61cf1fde76
        {
            get => this.currentTeam;
            set => this.currentTeam = value;
        }

        public Aircraft CurrentAircraft
        {
            get => this.currentAircraft;
            set => this.currentAircraft = value;
        }

        private ObservableCollection<Aircraft> listOfAircrafts;
        public ObservableCollection<Aircraft> ListOfAircrafts
        {
            get => this.listOfAircrafts;
            set
            {
                this.listOfAircrafts = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Team> listOfTeams;
        public ObservableCollection<Team> ListOfTeams
        {
            get => this.listOfTeams;
            set
            {
                this.listOfTeams = value;
                RaisePropertyChanged();
            }
        }

        public CreateTeamsPageViewModel(IFacade facade, IPageDialogService dialogService, INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Create Teams";
            this._facade = facade;
            this._dialogService = dialogService;
            this._navService = navigationService;
            this.GetAircraftsInfo();
            this.GetTeamsInfo();
            this.AddTeamCommand = new DelegateCommand(async () => await this.AddTeam());
        }

        private async Task AddTeam()
        {
            try
            {
                var result = await this._facade.AssignTeamToAircraft(CurrentAircraft.Id, CurrentTeam.ID);
                if (result.HasBeenSuccessful)
                {
                    await this._navService.NavigateAsync(nameof(Views.MainPage));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

            }
        }

        public async void GetAircraftsInfo()
        {
            try
            {
                var result = await this._facade.GetAircrafts();
                Console.WriteLine(result);
                if (result.HasBeenSuccessful)
                {
                    var listToObservable = new ObservableCollection<Aircraft>(result.Content.ToList());
                    ListOfAircrafts = listToObservable;

                }
                else
                {
                    var dialogResult = await this._dialogService.DisplayAlertAsync("Error", "Something went wrong, couldn't retrieve the aircrafts' data", "Try again", "OK");
                    if (dialogResult)
                    {
                        this.GetAircraftsInfo();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public async void GetTeamsInfo()
        {
            try
            {
                var result = await this._facade.GetTeams();
                Console.WriteLine(result);
                if (result.HasBeenSuccessful)
                {
                    var listToObservable = new ObservableCollection<Team>(result.Content.ToList());
                    ListOfTeams = listToObservable;

                }
                else
                {
                    var dialogResult = await this._dialogService.DisplayAlertAsync("Error", "Something went wrong, couldn't retrieve the aircrafts' data", "Try again", "OK");
                    if (dialogResult)
                    {
                        this.GetTeamsInfo();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
