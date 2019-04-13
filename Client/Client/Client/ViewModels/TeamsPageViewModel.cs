using Client.Enums;
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

namespace Client.ViewModels
{ 
	public class TeamsPageViewModel : ViewModelBase
	{
        private readonly IFacade facade;
        private ObservableCollection<Team> teamsList;
        private readonly INavigationService navService;
        private readonly IPageDialogService dialogService;
        public DelegateCommand<Team> NavToTeamDetailsCommand { get; set; }

        public ObservableCollection<Team> TeamsList
        {
            get => this.teamsList;
            set
            {
                this.teamsList = value;
                RaisePropertyChanged();
            }
        }

        private Team onTeamSelected;

        public Team OnTeamSelected {
            get => this.onTeamSelected;

            set
            {
                if (this.onTeamSelected == null && value != null)
                {
                    this.onTeamSelected = value;
                    this.NavToTeamDetailsCommand.Execute(OnTeamSelected);
                    this.onTeamSelected = null;
                    value = null;
                    RaisePropertyChanged();
                }
                
            }
        }

        

        public TeamsPageViewModel(INavigationService navigationService, IFacade facadeImpl, IPageDialogService dialogServiceImpl)
            : base(navigationService)
        {
            //this.OnTeamSelected = null;
            this.Title = "Teams Database";
            this.onTeamSelected = null;
            this.facade = facadeImpl;
            this.navService = navigationService;
            this.dialogService = dialogServiceImpl;
            this.NavToTeamDetailsCommand = new DelegateCommand<Team>(async (teamPressed) => {
                NavigationParameters navParams = new NavigationParameters();
                navParams.Add("teamId",teamPressed.ID);
                navParams.Add("teamName", teamPressed.Name);
                await this.navService.NavigateAsync(nameof(Views.TeamDetailsPage), navParams);
            });
            this.GetTeamsList();

        }

        private async void GetTeamsList()
        {
            try
            { 

                var result = await this.facade.GetTeams();
                if (result.HasBeenSuccessful)
                {
                    var listToObservable = new ObservableCollection<Team>(result.Content.ToList());
                    TeamsList = listToObservable;
                }
                else
                {
                    var dialogResult = await this.dialogService.DisplayAlertAsync("Error", "Something went wrong, couldn't retrieve teams database", "Try again", "OK");
                    if (dialogResult)
                    {
                        this.GetTeamsList();
                    }
                    await this.navService.NavigateAsync(nameof(Views.MainPage));
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}