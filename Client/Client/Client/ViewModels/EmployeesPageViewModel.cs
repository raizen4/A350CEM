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
	public class EmployeesPageViewModel : ViewModelBase
	{
        private IFacade facade;
        private List<Employee> employees;

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

        public EmployeesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this.navService = NavigationService;
            this.Title = "Employees";
        }
    }
}
