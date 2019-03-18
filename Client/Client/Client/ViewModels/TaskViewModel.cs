using Client.Interfaces;
using Client.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.ViewModels
{
	public class TaskViewModel : ViewModelBase
	{
        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;
        private  List<ServiceTask> listOfTasksForCurrentAircraft;


        public DelegateCommand<ServiceTask> MarkTaskAsCompletedCommand { get; set; }
        public List<ServiceTask> ListOfTasksForCurrentAircraft {
            get => this.listOfTasksForCurrentAircraft;
            set => this.listOfTasksForCurrentAircraft = value;
        }
        

        public TaskViewModel(INavigationService navigationService, IFacade facade, IPageDialogService dialogService) : base(navigationService)
        {
            this._facade = facade;
            this._navService = navigationService;
            this._dialogService = dialogService;
            this.MarkTaskAsCompletedCommand = new DelegateCommand<ServiceTask>(async (taskPressed) => await this.MarkTaskAsCompleted(taskPressed));
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            List<ServiceTask> tasksReceived;
            try
            {
                parameters.TryGetValue("Tasks", out tasksReceived);
                if (tasksReceived != null)
                {
                    ListOfTasksForCurrentAircraft = tasksReceived;
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
                var result = await this._facade.MarkTaskAsCompleted(taskToBeCompleted);
                if (result.HasBeenSuccessful)
                {
                    await this._dialogService.DisplayAlertAsync("Succedded", "Task marked as completed", "OK");
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
    }
}
