﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class ServiceTask
    {
        private string _id;
        private string _name;
        private string _description;
        private string _status;
        private string _date;
        private string _title;
        private bool isExtendedView=false;


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
        public string Title
        {
            get => this._title;
            set => this._title = value;
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
