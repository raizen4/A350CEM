using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Aircraft
    {
        private string _id;
        private string _name;
        private string _engTeam;
        private string _flyHours;
        private string _taskHistory;

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
        public string EngTeam
        {
            get => this._engTeam;
            set => this._engTeam = value;
        }
        public string FlyHours
        {
            get => this._flyHours;
            set => this._flyHours = value;
        }
        public string TaskHistory
        {
            get => this._taskHistory;
            set => this._taskHistory = value;
        }
    }
}
