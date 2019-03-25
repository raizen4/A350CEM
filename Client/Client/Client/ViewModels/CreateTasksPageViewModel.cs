using Client.Interfaces;
using Client.Models;
using Client.ServiceModels;
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
    public class CreateTasksPageViewModel : ViewModelBase
    {
        private IFacade _facade;
        private readonly IPageDialogService _dialogService;
        private readonly INavigationService _navService;
        private ServiceTask currentTask;
        private Aircraft currentAircraft;

        public string AircraftId;
        public string Description;
        public string Status;
        public string Title;

        public DelegateCommand GoToMainPage { get; set; }
        public DelegateCommand AddTaskCommand { get; set; }

        public ServiceTask CurrentTask
        {
            get => this.currentTask;
            set => this.currentTask = value;
        }

        public Aircraft CurrentAircraft
        {
            get => this.currentAircraft;
            set => this.currentAircraft = value;
        }

        private ObservableCollection<Aircraft> listOfAircrafts;
        public ObservableCollection<Aircraft> ListOfAircrafts;

        public CreateTasksPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IFacade facadeImplementation)
            : base(navigationService)
        {
            Title = "Create Tasks";
            this._navService = navigationService;
            this.GoToMainPage = new DelegateCommand(async () => await this._navService.NavigateAsync(nameof(Views.MainPage)));
            AddTaskCommand = new DelegateCommand(async () => await AddTask(AircraftId, Title, Status, Description));
            this.GetAircraftsInfo();

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
                    new ServiceTask() {Id="T Id 1", Description="Test Description", Status="Assigned", Title="Title"},
                    new ServiceTask() {Id="T Id 2", Description="Test Description", Status="Assigned", Title="Title"},
                    new ServiceTask() {Id="T Id 3", Description="Test Description", Status="Assigned", Title="Title"},
                    new ServiceTask() {Id="T Id 4", Description="Test Description", Status="Assigned", Title="Title"},
                };
            }
        }

        private async Task AddTask(string AircraftId, string Title, string Status, string Description)
        {
            try
            {
                var result = await this._facade.AssignTaskToAircraft(CurrentAircraft.Id, CurrentTask.Title, CurrentTask.Status, CurrentTask.Description);
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

        public async void GetAircraftsInfo()
        {
            try
            {
                var result = await this._facade.GetAircrafts();
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
    }
}
