using Client.Interfaces;
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
	public class LoginPageViewModel : ViewModelBase
	{
       

        #region public properties
        public string Password
        {
            get => this._password;
            set => this._password = value;
        }

        
        #endregion

        #region public commands
        public DelegateCommand LogInCommand { get; set; }

        #endregion

        #region private variables
       
        private string _password;
        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;
        #endregion

        public LoginPageViewModel(INavigationService navigationService, IFacade facadeImplementation, IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Authenticate Page";
            this._navService = navigationService;
            this._dialogService = dialogService;
            this.LogInCommand = new DelegateCommand(async () => await this.Login());
            this._facade = facadeImplementation;
        }

        public async Task Login()
        {
            if (this.Password.Length==0)
            {
                await this._dialogService.DisplayAlertAsync("Error",
                      "Password field is empty. Please fill it to be able to log in.", "OK");
            }
            else
            {
                IsLoading = true;
                try
                {
                    var currentUserLoggedIn = await this._facade.Login(Password);
                    IsLoading = false;
                    if (currentUserLoggedIn.HasBeenSuccessful)
                    {
                        Constants.LoggedUser = currentUserLoggedIn.Content;
                        await this.NavigationService.NavigateAsync(nameof(Views.MainPage));
                    }
                    else
                    {

                        await this._dialogService.DisplayAlertAsync("Error",
                            "Password wrong. Please try again", "OK");
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
               

            }



        }

    }
}

