using Client.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Client.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {

        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;

        public DelegateCommand GoToAircraftInfoPage { get; set; }
        public DelegateCommand GoToEmployeesPage { get; set; }

        public DelegateCommand GoToCreateATaskPage { get; set; }

        public DelegateCommand LogoutCommand { get; set; }



        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Menu Page";
        }
    }
}
