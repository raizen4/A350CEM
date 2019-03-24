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
        private IFacade _facade;
        private readonly INavigationService _navService;

        public DelegateCommand GoToMainPage { get; set; }

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

        public CreateTeamsPageViewModel(INavigationService navigationService, IFacade facade) : base(navigationService)
        {
            Title = "Create Teams";
            this._facade = facade;
            this.GoToMainPage = new DelegateCommand(() => this._navService.NavigateAsync(nameof(Views.MainPage)));
        }
    }
}
