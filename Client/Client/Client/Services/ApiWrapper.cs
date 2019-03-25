using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Refit;

namespace Client.ApiWrapperImplementation
{
    using System.Net.Http.Headers;
    using System.Text;
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
            var content = new StringContent(jsonToSend, Encoding.UTF8, Constants.Headers.ContentType);

            var result = await this.API.Authenticate(Constants.Headers.ContentType, content);          
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
        public async Task<HttpResponseMessage> GetTeam(GetTeamRequest req)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var jsonToSend = JsonConvert.SerializeObject(req);
            var content = new StringContent(jsonToSend, Encoding.UTF8, Constants.Headers.ContentType);
            var result = await this.API.GetTeam(Constants.Headers.ContentType, content);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetTeamMembers(GetTeamMembersRequest req)
        {
            var getTeamMembersForm = new GetTeamMembersRequest();
            getTeamMembersForm.teamId = req.teamId;
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var jsonToSend = JsonConvert.SerializeObject(req);
            var content = new StringContent(jsonToSend, Encoding.UTF8, Constants.Headers.ContentType);
            var result = await this.API.GetTeamMembers(Constants.Headers.ContentType, content);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> AddMemberToTeam(AddMemberRequest req)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var jsonToSend = JsonConvert.SerializeObject(req);
            var content = new StringContent(jsonToSend, Encoding.UTF8, Constants.Headers.ContentType);
            var result = await this.API.AddMemberToTeam(Constants.Headers.ContentType, content);
            return result;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> CreateTask(CreateTaskRequest req)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var jsonToSend = JsonConvert.SerializeObject(req);
            var content = new StringContent(jsonToSend, Encoding.UTF8, Constants.Headers.ContentType);
            var result = await this.API.CreateTask(Constants.Headers.ContentType, content);
            return result;
        }

    

        public async Task<HttpResponseMessage> MarkTaskAsCompleted(TaskRequest req)
        {
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var jsonToSend = JsonConvert.SerializeObject(req);
            var content = new StringContent(jsonToSend, Encoding.UTF8, Constants.Headers.ContentType);
            var result = await this.API.MarkTaskAsCompleted(Constants.Headers.ContentType, content);
            return result;
        }

        public async Task<HttpResponseMessage> GetTasksForAircraft(GetTasksForAircraftRequest req)
        {
            var getAircraftTasksForm = new GetTasksForAircraftRequest();
            getAircraftTasksForm.AircraftId = req.AircraftId;
            this.client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Constants.Token);
            var jsonToSend = JsonConvert.SerializeObject(req);
            var content = new StringContent(jsonToSend, Encoding.UTF8, Constants.Headers.ContentType);
            var result = await this.API.GetTasksForAircraft(Constants.Headers.ContentType, content);
            return result;
        }
    }
}

