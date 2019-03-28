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
using System.Threading.Tasks;

namespace Client.ViewModels
{
	public class AircraftTasksPageViewModel : ViewModelBase
	{
        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;
        private ObservableCollection<ServiceTask> listOfTasksForCurrentAircraft;


        public DelegateCommand<ServiceTask> MarkTaskAsCompletedCommand { get; set; }
        public ObservableCollection<ServiceTask> ListOfTasksForCurrentAircraft {
            get => this.listOfTasksForCurrentAircraft;
            set { this.listOfTasksForCurrentAircraft = value;
                RaisePropertyChanged();
            }

        }
        

        public AircraftTasksPageViewModel(INavigationService navigationService, IFacade facade, IPageDialogService dialogService) : base(navigationService)
        {
            this.Title = "Task history";
            this._facade = facade;
            this._navService = navigationService;
            this._dialogService = dialogService;
            this.MarkTaskAsCompletedCommand = new DelegateCommand<ServiceTask>(async (taskPressed) => await this.MarkTaskAsCompleted(taskPressed));
        }


        public async override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            string aircraftId;
            try
            {
                parameters.TryGetValue("AircraftId", out aircraftId);
                if (aircraftId != null)
                {
                    
                    var getTasksResult = await this._facade.GetTasksForAircraft(aircraftId);
                    if (getTasksResult.HasBeenSuccessful)
                    {
                        var listToObservableCollection = new ObservableCollection<ServiceTask>(getTasksResult.Content);
                        ListOfTasksForCurrentAircraft = listToObservableCollection;
                    }
                    else
                    {
                        await this._dialogService.DisplayAlertAsync("Failed", "Something went wrong, try again", "OK");
                        await this._navService.GoBackAsync();

                    }

                }
            }
            catch(Exception e)
            {
                //fail silently
            }
        }

        public async Task MarkTaskAsCompleted(ServiceTask taskToBeCompleted)
        {
            try
            {
                var result = await this._facade.MarkTaskAsCompleted(taskToBeCompleted.Id);
                if (result.HasBeenSuccessful)
                {
                    await this._dialogService.DisplayAlertAsync("Succedded", "Task marked as completed", "OK");
                    var currentTaskPressedIndex = ListOfTasksForCurrentAircraft.IndexOf(taskToBeCompleted);
                    var currentTask = taskToBeCompleted;
                    currentTask.Status = ServiceTaskStatusesEnum.StatusCompleted;
                    ListOfTasksForCurrentAircraft.RemoveAt(currentTaskPressedIndex);
                    ListOfTasksForCurrentAircraft.Insert(currentTaskPressedIndex, currentTask);
                }
                else
                {
                    await this._dialogService.DisplayAlertAsync("Failed", "Something went wrong, try again", "OK");

                }
            }
            catch(Exception e){
                await this._dialogService.DisplayAlertAsync("Failed", "Something went wrong, try again", "OK");

            }
        }
        internal void ShowOrHideExtension(ServiceTask taskPressed)
        {
            var currentTaskPressedIndex = ListOfTasksForCurrentAircraft.IndexOf(taskPressed);
            var currentTask = taskPressed;
            if (currentTaskPressedIndex == -1)
            {
                currentTaskPressedIndex++;
            }
            currentTask.IsExtendedView = !currentTask.IsExtendedView;
            ListOfTasksForCurrentAircraft.RemoveAt(currentTaskPressedIndex);
            ListOfTasksForCurrentAircraft.Insert(currentTaskPressedIndex, currentTask);

        }

    }
}
