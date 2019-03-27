using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Models
{
    public class MarlTaskAsCompleted
    {
        private string _id;
        private string _description;
        private string _status;
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
       
    }
}
