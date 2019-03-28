using System;
using System.Collections.Generic;
using System.Text;

namespace Client.ServiceModels
{

    public class ResponseData<T> : ResponseBase
    {
        public T Content;

        public bool HasBeenSuccessFul { get; internal set; }
    }

}
