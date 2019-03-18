using Client.Enums;
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
    public class AircraftInfoPageViewModel : ViewModelBase
    {

        private readonly IFacade _facade;
        private readonly INavigationService _navService;
        private readonly IPageDialogService _dialogService;
        private List<Aircraft> listOfAircrafts;

        public List<Aircraft> ListOfAircrafts
        {
            get => this.listOfAircrafts;
            set => this.listOfAircrafts = value;
        }

        public AircraftInfoPageViewModel(IFacade facade, IPageDialogService dialogService, INavigationService navigationService) : base(navigationService)
        {
            this._facade = facade;
            this._dialogService = dialogService;
            this._navService = navigationService;
            this.ListOfAircrafts = new List<Aircraft>()
            {
                new Aircraft()
                {
                    FlyHours="50",
                    EngTeam="Bosii",
                    ID="231445",
                    Name="Boeing 737 800 V2",
                    TaskHistory=new List<ServiceTask>()
                    {
                        new ServiceTask()
                        {
                            Date=DateTime.Now.ToShortTimeString(),
                            Description=TaskDescriptionsEnum.Task1,
                            Status=ServiceTaskStatusesEnum.StatusAssigned,
                            ID="2132132",
                            Name="Something really important",
                        }
                    }
                },
                new Aircraft()
                {
                    FlyHours="50",
                    EngTeam="Bosii",
                    ID="231445",
                    Name="Airbus A320",
                    TaskHistory=new List<ServiceTask>()
                    {
                        new ServiceTask()
                        {
                            Date=DateTime.Now.ToShortTimeString(),
                            Description=TaskDescriptionsEnum.Task1,
                            Status=ServiceTaskStatusesEnum.StatusAssigned,
                            ID="2132132",
                            Name="Something really important",
                        }
                    }
                },
                new Aircraft()
                {
                    FlyHours="200",
                    EngTeam="Macaronarii",
                    ID="23142",
                    Name="Boeing 787",
                    TaskHistory=new List<ServiceTask>()
                    {
                        new ServiceTask()
                        {
                            Date=DateTime.Now.ToShortTimeString(),
                            Description=TaskDescriptionsEnum.Task1,
                            Status=ServiceTaskStatusesEnum.StatusAssigned,
                            ID="2132132",
                            Name="Something really important",
                        }
                    }
                }
            };
            //this.GetAircraftsInfo();
        }

        public async void GetAircraftsInfo()
        {
            try
            {

                var result = await this._facade.GetAircrafts();
                if (result.HasBeenSuccessful)
                {
                    ListOfAircrafts = result.Content.ToList();

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
    }
}
