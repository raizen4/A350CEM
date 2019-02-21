using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class Team
    {
        private string _id;
        private string _name;
        private string _type;
        private string _members;

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
        public string Type
        {
            get => this._type;
            set => this._type = value;
        }
        public string Members
        {
            get => this._members;
            set => this._members = value;
        }
    }
}
