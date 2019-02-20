using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
    interface IApiEndpoints
    {
        [Get("/Api/Employee/GetEmployees")]
        Task<HttpResponseMessage> GetEmployees();

    }
}
