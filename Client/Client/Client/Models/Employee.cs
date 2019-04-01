using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Employee
    {
        private string _id;
        private string _spec;
        private string _teamId;
        private string _name;
        private string _manHours;
        private string _token;


        public string Token
        {
            get => this._token;
            set => this._token = value;
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
        public string Team  
        {
            get => this._teamId;
            set => this._teamId = value;
        }
        public string ManHours
        {
            get => this._manHours;
            set => this._manHours = value;
        }
        public string Spec
        {
            get => this._spec;
            set => this._spec = value;
        }
    }
}
