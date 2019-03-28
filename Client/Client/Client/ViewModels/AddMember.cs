using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using Prism.Services;
using Client.Interfaces;
using Client.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;


namespace Client.ViewModels
{
	public class AddNewMember : ViewModelBase
    {
        private string team_ID;
        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;

        private Employee currentEmployee;

        public DelegateCommand AddMember {get; set;}

        public Employee CurrentEmployee {
        	get => this.currentEmployee;
        	set => this.currentEmployee = value;
        }

        private ObservableCollection<Employee> listOfEmployee;
		public ObservableCollection<Employee> ListOfEmployee {
			get => this.listOfEmployee;
			set 
			{
				this.listOfEmployee = value;
				RaisePropertyChanged();
			}
		}

        public AddNewMember(IFacade facade, IPageDialogService dialogService, INavigationService navigationService) : base (navigationService)
        {
            this.Title = "Employees Database";
            this.AddMember = new DelegateCommand(async () => await this.AddTeamMember());
            this._dialogService = dialogService;
            this._navService = navigationService;
            this._facade = facade;
            this.GetMemberInfo();

        }

        private async Task AddTeamMember() {
        	try
        	{
        		var result = await this._facade.AddMemberToTeam(CurrentEmployee.ID, team_ID);
        		if (result.HasBeenSuccessful)
        		{
                    await this._navService.NavigateAsync(nameof(Views.TeamDetailsPage));
        		}
        	}
        	catch (Exception e)
        	{
        		Console.WriteLine(e.Message);
        	}

        }
         public async override void OnNavigatedTo(INavigationParameters parameters) {
         	base.OnNavigatedTo(parameters);
         	try {
         		parameters.TryGetValue("TeamID", out team_ID);
         		if (team_ID == null) {
         			await this._dialogService.DisplayAlertAsync("failed", "something went wrong", "OK");
         			await this._navService.GoBackAsync();
         		}
         	} catch (Exception e) {
         		Console.WriteLine(e.Message);
         	}
         }

        public async void GetMemberInfo() {
        	try
            {
        		var result = await this._facade.GetEmployees();
        		Console.WriteLine(result);
        		if (result.HasBeenSuccessful) {
        			var listToObservable = new ObservableCollection<Employee> (result.Content.ToList());
        			ListOfEmployee = listToObservable;
        		}
                else
                {
                    var dialogResult = await this._dialogService.DisplayAlertAsync("Error", "Something went wrong, couldn't retrieve the aircrafts' data", "Try again", "OK");
                    if (dialogResult)
                    {
                        this.GetMemberInfo();
                    }
                }
            } 
        	catch (Exception e) {
        		Console.WriteLine(e.Message);
        	}
        }
	}
}
