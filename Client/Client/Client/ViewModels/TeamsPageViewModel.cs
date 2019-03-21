using Client.Enums;
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
	public class TeamsPageViewModel : ViewModelBase
	{
        private readonly IFacade facade;
        private List<Team> teamsList;
        private readonly INavigationService navService;
        public DelegateCommand<Team> NavToTeamDetailsCommand { get; set; }

        public List<Team> TeamsList
        {
            get => this.teamsList;
            set => this.teamsList = value;
        }

        private Team onTeamSelected;

        public Team OnTeamSelected {
            get => this.onTeamSelected;

            set
            {
                if (this.onTeamSelected == null)
                {
                    this.onTeamSelected = value;
                    this.NavToTeamDetailsCommand.Execute(OnTeamSelected);
                    RaisePropertyChanged();
                }
                else
                { 
                    if (this.onTeamSelected.Name != value.Name)
                    {
                        this.onTeamSelected = value;
                        RaisePropertyChanged();
                        this.NavToTeamDetailsCommand.Execute(OnTeamSelected);
                    }
                }
            }
        }

        public TeamsPageViewModel(INavigationService navigationService, IFacade facadeImpl)
            : base(navigationService)
        {
            //this.OnTeamSelected = null;
            this.facade = facadeImpl;
            this.navService = navigationService;
            this.NavToTeamDetailsCommand = new DelegateCommand<Team>(async (teamPressed) => {
                NavigationParameters navParams = new NavigationParameters();
                navParams.Add("TeamDetail",teamPressed);
                await this.navService.NavigateAsync(nameof(Views.TeamDetailsPage), navParams);
            });
            this.TeamsList = new List<Team>()
            {
                new Team()
                {
                    Name ="Mistocarii",
                    Members =new List<Employee>() {
                        new Employee()
                        {
                            ID =  "1000000",
                            Name = "Vlad",
                            ManHours = "42",
                            Spec = "Software Developer",
                        },
                        new Employee()
                        {
                            ID =  "2000000",
                            Name = "Bogdan",
                            ManHours = "39",
                            Spec = "Engineer",
                        },
                        new Employee()
                        {
                            ID =  "3000000",
                            Name = "Pojo",
                            ManHours = "Tester",
                            Spec = "Engineer",
                        }
                    },
               
                    Type ="Maintenance"},
                new Team()
                {
                    Name ="Idiotii",
                    Members =new List<Employee>() {
                        new Employee()
                        {
                            ID =  "4000000",
                            Name = "Oana",
                            ManHours = "21",
                            Spec = "Software Developer",
                        },
                        new Employee()
                        {
                            ID =  "5000000",
                            Name = "Paula",
                            ManHours = "39",
                            Spec = "Engineer",
                        },
                        new Employee()
                        {
                            ID =  "6000000",
                            Name = "Prietena lui Pojo",
                            ManHours = "Tester",
                        }
                    },
                    Type ="Testing"},
                new Team(){
                    Name ="Boldurii",
                    Members =new List<Employee>() {
                        new Employee()
                        {
                            ID =  "7000000",
                            Name = "Bobita",
                            ManHours = "27",
                            Spec = "Software Architecturer",
                        },
                        new Employee()
                        {
                            ID =  "7000000",
                            Name = "Nicolae Guta",
                            ManHours = "39",
                            Spec = "enterteiner",

                        },
                        new Employee()
                        {
                            ID =  "8000000",
                            Name = "Folrin 'regele' Salam",
                            ManHours = "Tester",
                            Spec = "The King",
                        }
                    },
                    Type ="Optionla"
                },
                new Team()
                {
                    Name ="Bolovanii",
                    Members =new List<Employee>() {
                        new Employee()
                        {
                            ID =  "434000000",
                            Name = "Doc",
                            ManHours = "42",
                            Spec = "Singer",
                        },
                        new Employee()
                        {
                            ID =  "9000000",
                            Name = "Deliric",
                            ManHours = "39",
                            Spec = "Engineer",
                        },
                        new Employee()
                        {
                            ID =  "99000000",
                            Name = "Vlad Dobrescu",
                            ManHours = "Tester",
                            Spec = "Engineer",
                        }
                    },
                    Type ="Nothing special"
                },
                new Team()
                {
                    Name ="Biciuitorii",
                    Members =new List<Employee>() {
                        new Employee()
                        {
                            ID =  "42313000000",
                            Name = "Cheloo",
                            ManHours = "42",
                        },
                        new Employee()
                        {
                            ID =  "555325000",
                            Name = "Ombladon",
                            ManHours = "39",
                            Spec = "Engineer",

                        },
                        new Employee()
                        {
                            ID =  "6442432",
                            Name = "Freakadadisk",
                            ManHours = "Tester",
                            Spec = "Engineer",
                        }
                    },
                    Type ="Head Office"
                },
            };
            Title = "Teams Page";
        }
    }
}