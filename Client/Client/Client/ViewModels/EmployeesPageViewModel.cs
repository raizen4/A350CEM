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

namespace Client.ViewModels
{
	public class EmployeesPageViewModel : ViewModelBase
	{
        private IFacade _facade;
        private readonly IPageDialogService _dialogService;
        private readonly INavigationService _navService;

        private List<Employee> employees;
        private ObservableCollection<Employee> listOfEmployees;

        private ObservableCollection<Employee> ListOfEmployees;

        public List<Employee> Employees
        {
            get
            {
                return new List<Employee>()
                {
                    new Employee() {Name="Name 1", Team="Team 1", Spec="Spec 1", ManHours="ManHours 1"},
                    new Employee() {Name="Name 2", Team="Team 2", Spec="Spec 2", ManHours="ManHours 2"},
                    new Employee() {Name="Name 3", Team="Team 3", Spec="Spec 3", ManHours="ManHours 3"},
                    new Employee() {Name="Name 4", Team="Team 4", Spec="Spec 4", ManHours="ManHours 4"},
                };
            }
        }


        private readonly INavigationService navService;

        public EmployeesPageViewModel(INavigationService navigationService, IPageDialogService dialogService, IFacade facade) : base(navigationService)
        {
            this.navService = NavigationService;
            this.Title = "Employees";
            this.GetEmployeesInfo();
            this._facade = facade;
            this._dialogService = dialogService;
        }

        public async void GetEmployeesInfo()
        {
            try
            {

                var result = await this._facade.GetEmployees();
                if (result.HasBeenSuccessful)
                {
                    var listToObservable = new ObservableCollection<Employee>(result.Content.ToList());
                    ListOfEmployees = listToObservable;

                }
                else
                {
                    var dialogResult = await this._dialogService.DisplayAlertAsync("Error", "Something went wrong, couldn't retrieve the Employees' data", "Try again", "OK");
                    if (dialogResult)
                    {
                        this.GetEmployeesInfo();
                    }
                    await this._navService.NavigateAsync(nameof(Views.MainPage));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
