﻿using Client.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;
        private string userName;

        public string UserName { get; set; }
        public DelegateCommand GoToAircraftInfoPage { get; set; }
        public DelegateCommand GoToEmployeesPage { get; set; }
        public DelegateCommand GoToAircraftManagement { get; set; }
        public DelegateCommand GoToTeamsListPage { get; set; }
        public DelegateCommand LogoutCommand { get; set; }



        public MainPageViewModel(INavigationService navigationService, IFacade facade, IPageDialogService dialogService)
            : base(navigationService)
        {

            Title = "Menu Page";
            this.LogoutCommand = new DelegateCommand(() => this.LogOut());
            this.GoToAircraftManagement = new DelegateCommand(() => this._navigatoToAircraftManagement());
            this._navService = navigationService;
            this._facade = facade;
            this._dialogService = dialogService;
            this.GoToAircraftInfoPage = new DelegateCommand(async () => await this._navService.NavigateAsync(nameof(Views.AircraftInfoPage)));
            this.GoToTeamsListPage = new DelegateCommand(async () => await this._navService.NavigateAsync(nameof(Views.TeamsPage)));
            this.UserName = Constants.LoggedUser.Name;
        }

        private async void _navigatoToAircraftManagement()
        {
            var dialogResult = await this._dialogService.DisplayActionSheetAsync("Aircraft Management", "Where do you want to navigate next?", "Cancel", "Add Team", "Add Task");
            if (dialogResult == "Add Team")
            {
               
                await this._navService.NavigateAsync(nameof(Views.CreateTeamsPage));
            } else if (dialogResult == "Add Task")
            {
               
                await this._navService.NavigateAsync(nameof(Views.CreateTasksPage));
            }
        }

        private async void LogOut()
        {
            var dialogResult = await this._dialogService.DisplayAlertAsync("Log Out", "Are you sure you want to log out?", "Yes", "No");
            if (dialogResult)
            {
                Constants.Token = "";
                Constants.LoggedUser = null;
                await this._navService.NavigateAsync(nameof(Views.LoginPage));
            }
        }
    }
}
