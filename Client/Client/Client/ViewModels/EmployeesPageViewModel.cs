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
        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;
        private ObservableCollection<Employee> listOfEmployees;

        public ObservableCollection<Employee> ListOfEmployees
        {
            get => this.listOfEmployees;
            set
            {
                this.listOfEmployees = value;
                RaisePropertyChanged();
            }
        }

        public EmployeesPageViewModel(IFacade facade, IPageDialogService dialogService, INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Employees Database";
            this._facade = facade;
            this._dialogService = dialogService;
            this._navService = navigationService;
            this.GetEmployeesInfo();
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
                    var dialogResult = await this._dialogService.DisplayAlertAsync("Error", "Something went wrong, couldn't retrieve the aircrafts' data", "Try again", "OK");
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
    }
}
