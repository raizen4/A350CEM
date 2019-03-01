using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ServiceModels
{
    public class ResponseData<T>:BaseResponse
    {
        public T Content;
    }
}
