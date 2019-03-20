using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Aircraft
    {
        private string _id;
        private string _name;
        private  Team _engTeam;
        private string _flyHours;
        private  List<ServiceTask> _taskHistory;
        private bool isExtendedView;


        public bool IsExtendedView
        {
            get => this.isExtendedView;
            set => this.isExtendedView = value;
        }
        public string ID
        {
            get => this._id;
            set => this._id = value;
        }
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }
        public Team EngTeam
        {
            get => this._engTeam;
            set => this._engTeam = value;
        }
        public string FlyHours
        {
            get => this._flyHours;
            set => this._flyHours = value;
        }
        public List<ServiceTask> TaskHistory
        {
            get => this._taskHistory;
            set => this._taskHistory = value;
        }
    }
}
