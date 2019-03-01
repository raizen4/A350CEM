using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModels
{
    public class BaseResponse
    {
        public int Code { get; set; }

        public bool IsSuccessful { get; set; }
    }
}
