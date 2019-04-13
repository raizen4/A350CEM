using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Aircraft
    {
        private string _id;
        private string _name;
        private  string _teamName;
        private string _teamId;
        private string _flyHours;
        private  List<string> _taskHistory;
        private bool isExtendedView = false;


        public bool IsExtendedView
        {
            get => this.isExtendedView;
            set => this.isExtendedView = value;
        }
        public string Id
        {
            get => this._id;
            set => this._id = value;
        }
        public string Name
        {
            get => this._name;
            set => this._name = value;
        }
        public string TeamName
        {
            get => this._teamName;
            set => this._teamName = value;
        }

        public string TeamId
        {
            get => this._teamId;
            set => this._teamId = value;
        }

        public string FlyingHours
        {
            get => this._flyHours;
            set => this._flyHours = value;
        }
        public List<string> TaskHistory
        {
            get => this._taskHistory;
            set => this._taskHistory = value;
        }
    }
}
