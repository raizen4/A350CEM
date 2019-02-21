using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ApiWrapper;
using Client.Dtos;
using Client.Models;
using ModernHttpClient;
using Refit;

namespace Client.ApiWrapperImplementation
{
    using System.Collections.Generic;
    using System.Net.Http.Headers;
    using Newtonsoft.Json;
    using ServicesModels;

    class ApiWrapper : IApiWrapperImplementation
    {
        private IApiMatchingMethods API;
        /// <summary>
        /// The HTTP client
        /// </summary>
        private HttpClient client;

        public ApiWrapper()
        {
            try
            {
                InitialiseApi();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception creating ApiWrapper: {0}", ex.Message);
                throw new Exception(ex.Message, ex);
            }

        }

        public void InitialiseApi()
        {
            this.client = new HttpClient(new NativeMessageHandler())
            {

                DefaultRequestHeaders = { Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token) },
                BaseAddress = new Uri(Constants.WebApiEndpoint),

            };
            try
            {
                this.API = RestService.For<IApiMatchingMethods>(this.client);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception creating ApiWrapper: {0}", ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> Login()
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.Login();
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetEmployees()
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.GetEmployees();
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetAircrafts()
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.GetAircrafts();
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetTeams()
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.GetTeams();
            return result;
        }


        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetMembers()
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.GetMembers();
            return result;
        }


        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetTasks()
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.GetTasks();
            return result;
        }
    }
}

