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
    public class TeamDetailsPageViewModel : ViewModelBase
    {
        private readonly IFacade facade;
        private readonly INavigationService navService;
        private readonly IPageDialogService dialogService;
        private ObservableCollection<Employee> teamMembersList;
        private string teamIdPassed;


        public string TeamIdPassed
        {
            get => this.teamIdPassed;
            set => this.teamIdPassed = value;
        }

        public DelegateCommand GoToAddMemberToTeamPage { get; set; }

        public ObservableCollection<Employee> TeamMembersList
        {
            get => this.teamMembersList;
            set
            {
                this.teamMembersList = value;
                RaisePropertyChanged();
            }

           
        }
       
        public TeamDetailsPageViewModel(INavigationService navigationService, IFacade facadeImpl, IPageDialogService dialogServiceImpl) : base(navigationService)
        {
            
            this.facade = facadeImpl;
            this.navService = navigationService;
            this.dialogService = dialogServiceImpl;
            this.GoToAddMemberToTeamPage = new DelegateCommand(async () => {
                NavigationParameters navParams = new NavigationParameters();
                navParams.Add("teamId", TeamIdPassed);
                await this.navService.NavigateAsync(nameof(Views.AddMemberToTeamPage), navParams);
            });
         

        }

        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            string teamId;
            string teamName;
            try
            {
                parameters.TryGetValue("teamId", out teamId);
                parameters.TryGetValue("teamName", out teamName);

                if (teamId != null)
                {
                    TeamIdPassed = teamId;
                    var getMembersResult = await this.facade.GetTeamMembers(teamId);
                    if (getMembersResult.HasBeenSuccessful)
                    {
                        var listToObservableCollection = new ObservableCollection<Employee>(getMembersResult.Content);
                        TeamMembersList = listToObservableCollection;
                        this.Title = teamName + ",  Members: " + TeamMembersList.Count.ToString();
                    }
                    else
                    {
                        await this.dialogService.DisplayAlertAsync("Failed", "Something went wrong, please try again", "OK");
                        await this.navService.GoBackAsync();
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
