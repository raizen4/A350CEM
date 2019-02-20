using Client.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Client.Interfaces
{
   public interface IApiWrapper
    {
        void InitializeApi();
        Task<HttpResponseMessage> GetEmployees();
    }
}
