using Client.Interfaces;
using Client.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModels
{
    public class CreateTeamsPageViewModel : ViewModelBase
    {
        private IFacade facade;

        public List<Aircraft> Aircrafts
        {
            get
            {
                return new List<Aircraft>()
                {
                    new Aircraft() {ID="A Id 1", Name="A Name 1"},
                    new Aircraft() {ID="A Id 2", Name="A Name 2"},
                    new Aircraft() {ID="A Id 3", Name="A Name 3"},
                    new Aircraft() {ID="A Id 4", Name="A Name 4"},
                };
            }
        }

        public List<ServiceTask> Teams
        {
            get
            {
                return new List<ServiceTask>()
                {
                    new ServiceTask() {ID="T Id 1", Name="T Name 1"},
                    new ServiceTask() {ID="T Id 2", Name="T Name 2"},
                    new ServiceTask() {ID="T Id 3", Name="T Name 3"},
                    new ServiceTask() {ID="T Id 4", Name="T Name 4"},
                };
            }
        }


        private readonly INavigationService navService;

        public CreateTeamsPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.navService = NavigationService;
            this.Title = "Create Team";
        }
    }
}
