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
    public class AircraftInfoPageViewModel : ViewModelBase
    {

        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;
        private ObservableCollection<Aircraft> listOfAircrafts;

       

        public DelegateCommand<Aircraft> NavigateToAircraftTasksCommand { get; set; }
        public ObservableCollection<Aircraft> ListOfAircrafts
        {
            get => this.listOfAircrafts;
            set
            { this.listOfAircrafts = value;
                RaisePropertyChanged();
            }
        }

        public AircraftInfoPageViewModel(IFacade facade, IPageDialogService dialogService, INavigationService navigationService) : base(navigationService)
        {
            this.Title = "Aircrafts Database";
            this.NavigateToAircraftTasksCommand = new DelegateCommand<Aircraft>(async (aircraftPressed) =>
              {
                  NavigationParameters navParams = new NavigationParameters();
                  navParams.Add("AircraftId", aircraftPressed.Id);
                  await this._navService.NavigateAsync(nameof(Views.AircraftTasksPage), navParams);
              });
            this._facade = facade;
            this._dialogService = dialogService;
            this._navService = navigationService;
            this.GetAircraftsInfo();
        }

        public async void GetAircraftsInfo()
        {
            try
            {

                var result = await this._facade.GetAircrafts();
                if (result.HasBeenSuccessful)
                {
                    var listToObservable = new ObservableCollection<Aircraft>(result.Content.ToList());
                    ListOfAircrafts = listToObservable;

                }
                else
                {
                   var dialogResult= await this._dialogService.DisplayAlertAsync("Error", "Something went wrong, couldn't retrieve the aircrafts' data", "Try again", "OK");
                    if (dialogResult)
                    {
                        this.GetAircraftsInfo();
                    }
                    await this._navService.NavigateAsync(nameof(Views.MainPage));
                }

            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        internal void ShowOrHideExtension(Aircraft aircraftPressed)
        {
            var currentAircraftPressedIndex = ListOfAircrafts.IndexOf(aircraftPressed);
            var currentAircraft = aircraftPressed;
            if (currentAircraftPressedIndex == -1)
            {
                currentAircraftPressedIndex++;
            }
            currentAircraft.IsExtendedView = !currentAircraft.IsExtendedView;
            ListOfAircrafts.RemoveAt(currentAircraftPressedIndex);
            ListOfAircrafts.Insert(currentAircraftPressedIndex, currentAircraft);
            
        }
    }
}
