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
        private List<Employee> _members;
        private List<ServiceTask> _tasks;


        public List<ServiceTask> Tasks
        {
            get => this._tasks;
            set => this._tasks = value;
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
        public string Type
        {
            get => this._type;
            set => this._type = value;
        }
        public List<Employee> Members
        {
            get => this._members;
            set => this._members = value;
        }
    }
}
