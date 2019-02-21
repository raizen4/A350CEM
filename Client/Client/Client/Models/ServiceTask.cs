using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class ServiceTask
    {
        private string _id;
        private string _name;
        private string _description;
        private string _team;
        private string _status;
        private string _date;


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
        public string Description
        {
            get => this._description;
            set => this._description = value;
        }
        public string Team
        {
            get => this._team;
            set => this._team = value;
        }
        public string Status
        {
            get => this._status;
            set => this._status = value;
        }
        public string Date
        {
            get => this._date;
            set => this._date = value;
        }
    }
}
