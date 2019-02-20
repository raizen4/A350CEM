using Client.Interfaces;
using Client.Models;
using ModernHttpClient;
using Refit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    class ApiWrapper : IApiWrapper
    {

        private IApiEndpoints API;
        /// <summary>
        /// The HTTP client
        /// </summary>
        private HttpClient client;

        public ApiWrapper()
        {
            try
            {
                InitializeApi();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception creating ApiWrapper: {0}", ex.Message);
                throw new Exception(ex.Message, ex);
            }




        }
        public void InitializeApi()
        {

            this.client = new HttpClient(new NativeMessageHandler())
            {

                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", "" )},
                BaseAddress = new Uri(Constants.WebApiEndpoint),

            };


            try
            {
                this.API = RestService.For<IApiEndpoints>(this.client);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception creating ApiWrapper: {0}", ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<HttpResponseMessage> GetEmployees()
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.LoggedUser.Token);

            var result = await this.API.GetEmployees();
            return result;
        }
    
    }
}
