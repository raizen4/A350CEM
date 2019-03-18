using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Refit;

namespace Client.ApiWrapperImplementation
{
    using System.Net.Http.Headers;
    using Client.Interfaces;
    using Client.ServiceModels;
    using Newtonsoft.Json;

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
                this.API = RestService.For<IApiEndpoints>(this.client);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Exception creating ApiWrapper: {0}", ex.Message);
                throw new Exception(ex.Message, ex);
            }
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> Login(LoginRequest req)
        {
            var jsonToSend = JsonConvert.SerializeObject(req);
            var result = await this.API.Login(Constants.Headers.ContentType,jsonToSend);          
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
        public async Task<HttpResponseMessage> GetTeam(string teamId)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.GetTeam(teamId);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetMembers(string teamId)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.GetMembers(teamId);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> AddMemberToTeam(string teamId)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.AddMemberToTeam(teamId);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> CreateTask(string aircraftId, string teamId, string description)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.CreateTask(aircraftId, teamId, description);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetTasksForAircraft(string aircraftId)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var result = await this.API.GetTasksForAircraft(aircraftId);
            return result;
        }
     
    }
}

