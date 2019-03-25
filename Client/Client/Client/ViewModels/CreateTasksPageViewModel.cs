using Client.Interfaces;
using Client.Models;
using Client.ServiceModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModels
{
    public class CreateTasksPageViewModel : ViewModelBase
    {
        private IFacade _facade;
        private readonly INavigationService _navService;

        public string AircraftId;
        public string TaskId;
        public string Description;

        public DelegateCommand GoToMainPage { get; set; }
        public DelegateCommand AddTaskCommand { get; set; }


        public CreateTasksPageViewModel(INavigationService navigationService, IFacade facadeImplementation)
            : base(navigationService)
        {
            Title = "Create Tasks";
            this._navService = navigationService;
            this.GoToMainPage = new DelegateCommand(async () => await this._navService.NavigateAsync(nameof(Views.MainPage)));
            AddTaskCommand = new DelegateCommand(async () => await AddTask(AircraftId, TaskId, Description));

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

        public List<ServiceTask> Tasks
        {
            get
            {
                return new List<ServiceTask>()
                {
                    new ServiceTask() {ID="T Id 1"},
                    new ServiceTask() {ID="T Id 2"},
                    new ServiceTask() {ID="T Id 3"},
                    new ServiceTask() {ID="T Id 4"},
                };
            }
        }

        private async Task AddTask(string AircraftId, string TaskId, string Description)
        {
            try
            {
                var result = await this._facade.AssignTaskToAircraft(AircraftId, TaskId, Description);
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
