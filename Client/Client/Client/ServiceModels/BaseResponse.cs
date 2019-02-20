using System;
using System.Collections.Generic;
using System.Text;

namespace Client.ServiceModels
{
    public class BaseResponse
    {
        public string Code { get; set; }
        public bool IsSuccessful { get; set; }

        public string Error { get; set; }
    }
}
