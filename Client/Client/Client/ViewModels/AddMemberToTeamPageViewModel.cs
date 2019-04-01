using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Client.ViewModels
{
	using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using Client.Models;
    using Interfaces;
	using Prism.Navigation;
	using Prism.Services;

	public class AddMemberToTeamPageViewModel : ViewModelBase
	{
		private ObservableCollection<Employee> listOfEmployess;
        private readonly INavigationService navService;
		private readonly IFacade facade;
		private readonly IPageDialogService dialogService;
		private string teamId;


		 public string TeamId
		{
			get => this.teamId;
			set => this.teamId = value;
		}
        public DelegateCommand FinishAdddingMembersCommand { get; set; }
		public ObservableCollection<Employee>  ListOfEmployees
		{
			get => this.listOfEmployess;
			set
			{
				if (this.listOfEmployess == null && value == null)
				{
                    ListOfEmployees = new ObservableCollection<Employee>();

                }
				else
				{
					this.listOfEmployess = value;
					RaisePropertyChanged();
                }
               
			}
		}
       
		

		/// <inheritdoc />
		public AddMemberToTeamPageViewModel(INavigationService navigationService, IFacade facade, IPageDialogService dialogService) : base(navigationService)
		{
			Title = "Add members to team";
            this.facade = facade;
			FinishAdddingMembersCommand=new DelegateCommand(AddMembersTask);
			this.navService = navigationService;
			this.dialogService = dialogService;
		
		}

		public async Task GetEmployeesInfo()
		{
			try
			{

				var result = await this.facade.GetEmployees();
				if (result.HasBeenSuccessful)
				{
					var listToObservable = new ObservableCollection<Employee>(result.Content.ToList());
                    ListOfEmployees = listToObservable;


                }
				else
				{
					var dialogResult = await this.dialogService.DisplayAlertAsync("Error", "Something went wrong, couldn't retrieve the employees data", "Try again", "OK");
					if (dialogResult)
					{
						this.GetEmployeesInfo();
					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}


		public async void AddMembersTask()
		{
			try
			{
                var selectedEmployees = new List<Employee>();
                foreach(Employee emp in ListOfEmployees)
                {
                    if (emp.IsSelected)
                    {
                        selectedEmployees.Add(emp);
                    }
                }
				var result = await this.facade.AddMemberToTeam(selectedEmployees, TeamId);
				if (result.HasBeenSuccessful)
				{

					 await this.dialogService.DisplayAlertAsync("Successful", "Employees added to team successfully", "OK");
					 await this.navService.NavigateAsync(nameof(Views.MainPage));

				}
				else
				{
					var dialogResult = await this.dialogService.DisplayAlertAsync("Error", "Something went wrong, couldn't retrieve the employees data", "Try again", "OK");
					if (dialogResult)
					{
						 this.AddMembersTask();
					}
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
        }
		public async override void OnNavigatedTo(INavigationParameters parameters)
		{
			base.OnNavigatedTo(parameters);
			try
			{
				string passedTeamId;
				parameters.TryGetValue("teamId", out passedTeamId);
				TeamId = passedTeamId;

				await GetEmployeesInfo();


            }
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
		}
        internal void ShowOrHideExtension(Employee employeePressed)
        {
            var currentTaskPressedIndex = ListOfEmployees.IndexOf(employeePressed);
            var currentEmployee = employeePressed;
            if (currentTaskPressedIndex == -1)
            {
                currentTaskPressedIndex++;
            }
            currentEmployee.IsSelected = !currentEmployee.IsSelected;
            ListOfEmployees.RemoveAt(currentTaskPressedIndex);
            ListOfEmployees.Insert(currentTaskPressedIndex, currentEmployee);

        }

    }


}
