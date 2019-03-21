using Client.Enums;
using Client.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Client.ViewModels
{
    public class TeamDetailsPageViewModel : ViewModelBase
    {

        private Team currentTeamSeen;
        private ObservableCollection<Employee> teamMembers;

        public ObservableCollection<Employee> TeamMembers
        {
            get
            {
                if (CurrentTeamSeen != null)
                {
                    var observableCollection = new ObservableCollection<Employee>(CurrentTeamSeen.Members);
                    return observableCollection;
                }
                else
                {
                    return new ObservableCollection<Employee>();
                }
            }
            set
            {
                this.CurrentTeamSeen.Members = value.ToList();
                RaisePropertyChanged();
            }

        }
        public Team CurrentTeamSeen
        {
            get => this.currentTeamSeen;
            set
            {
                this.currentTeamSeen = value;
                var observableCollection = new ObservableCollection<Employee>(CurrentTeamSeen.Members);
                this.TeamMembers = observableCollection;
            }
        }


        public TeamDetailsPageViewModel(INavigationService navigationService) : base(navigationService)
        {

        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            try
            {
                Team teamPassed;
                parameters.TryGetValue(NavigationParamsEnum.TeamSelected, out teamPassed);
                if (teamPassed.Name != null)
                {
                    Title = teamPassed.Name;
                    CurrentTeamSeen = teamPassed;

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
