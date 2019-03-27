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
        private readonly IFacade _facade;
        private readonly INavigationService _navService;
<<<<<<< HEAD
        private MarlTaskAsCompleted currentTask;
=======
        private readonly IPageDialogService _dialogService;

        private ServiceTask currentTask;
>>>>>>> ad2f7252bf14a89be1554bcccd425b61cf1fde76
        private Aircraft currentAircraft;

        public DelegateCommand AddTaskCommand { get; set; }

        public MarlTaskAsCompleted CurrentTask
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
        public ObservableCollection<Aircraft> ListOfAircrafts
        {
            get => this.listOfAircrafts;
            set
            {
                this.listOfAircrafts = value;
                RaisePropertyChanged();
            }
        }

        public List<ServiceTask> ListOfTasks
        {
            get => this.listOfTasks;
        }

<<<<<<< HEAD
        public List<MarlTaskAsCompleted> Tasks
        {
            get
            {
                return new List<MarlTaskAsCompleted>()
                {
                    new MarlTaskAsCompleted() {Id="1", Description="Oil Change", Status="Assigned", Title="Oil Change"},
                    new MarlTaskAsCompleted() {Id="2", Description="Repair Wing", Status="Assigned", Title="Repair Wing"},
                    new MarlTaskAsCompleted() {Id="3", Description="Clean Aircraft", Status="Assigned", Title="Clean Aircraft"},
                    new MarlTaskAsCompleted() {Id="4", Description="Put Gas", Status="Assigned", Title="Put Gas"},
                };
            }
=======
        public CreateTasksPageViewModel(IFacade facade, IPageDialogService dialogService, INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Create Tasks";
            this._facade = facade;
            this._dialogService = dialogService;
            this._navService = navigationService;
            this.GetAircraftsInfo();
            this.AddTaskCommand = new DelegateCommand(async () => await this.AddTask());
>>>>>>> ad2f7252bf14a89be1554bcccd425b61cf1fde76
        }

        private async Task AddTask()
        {
            try
            {
                var result = await this._facade.AssignTaskToAircraft(CurrentAircraft.Id, CurrentTask.Title, CurrentTask.Description, CurrentTask.Status);
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

        private List<ServiceTask> listOfTasks
        {
            get
            {
                return new List<ServiceTask>()
                {
                    new ServiceTask() {Id="1", Description="Oil Change is needed. Bring your won oil.", Status="Assigned", Title="Oil Change"},
                    new ServiceTask() {Id="2", Description="Repair Wing. Critical damage has been taken 5 minutes after departure, hiting birds.", Status="Assigned", Title="Repair Wing"},
                    new ServiceTask() {Id="3", Description="Clean Aircraft inside and out.", Status="Assigned", Title="Clean Aircraft"},
                    new ServiceTask() {Id="4", Description="Put Gas in the backup container", Status="Assigned", Title="Put Gas"},
                    new ServiceTask() {Id="5", Description="Fix Control Panel, one of the pilots droped food on it", Status="Assigned", Title="Control Panel Fix"},
                };
            }
        }
    }
}
