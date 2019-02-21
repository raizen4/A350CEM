using Client.Interfaces;
using Client.Models;
using Client.ServiceModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Client.Services
{
    class Facade : IFacade
    {
        private readonly IApiWrapper apiWrapper;
        public Facade(IApiWrapper apiWrapper)
        {
            this.apiWrapper = apiWrapper;
        }

        public async Task<ResponseData<IEnumerable<Team>>> AddMemberToTeamAsync(string teamId)
        {
            var responseData = new ResponseData<IEnumerable<Team>>()
            {
                HasBeenSuccessful = false
            };
            var result = await this.apiWrapper.AddMemberToTeam(string teamId);
            string content = await result.Content.ReadAsStringAsync();
            if(result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var deserializedContent = JsonConvert.DeserializeObject<ResponseData<IEnumerable<Team>>>(content);

                    if (!deserializedContent.HasBeenSuccessful || !deserializedContent.Content.Any())
                    {
                        responseData.HasBeenSuccessful = false;
                        responseData.Content = null;
                        responseData.Error = "Internal Server Error";
                        return responseData;
                    }

                    responseData.HasBeenSuccessful = true;
                    responseData.Content = deserializedContent.Content;
                    responseData.Error = null;
                    return responseData;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    responseData.HasBeenSuccessful = false;
                    responseData.Content = null;
                    responseData.Error = "Deserialization Error";
                    return responseData;
                }
            }
            throw new NotImplementedException();
        }

        public async Task<ResponseBase> CreateTask(string aircraftId, string teamId, string description)
        {
            var responseData = new ResponseBase
            {
                HasBeenSuccessful = false
            };

            var result = await this.apiWrapper.CreateTask(string aircraftId, string teamId, string description);
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var deserializedContent = JsonConvert.DeserializeObject<ResponseBase>(content);
                    if (!deserializedContent.HasBeenSuccessful || deserializedContent.Error != null)
                    {
                        responseData.HasBeenSuccessful = false;
                        responseData.Error = "Internal Server Error";
                        return responseData;
                    }
                    responseData.HasBeenSuccessful = true;
                    responseData.Error = null;
                    return responseData;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    responseData.HasBeenSuccessful = false;
                    responseData.Error = "Deserialization Error";
                    return responseData;
                }
            }
            responseData.HasBeenSuccessful = false;
            responseData.Error = "Internal Error" + result.StatusCode.ToString();
            return responseData;
            throw new NotImplementedException();
        }

        public Task<ResponseData<IEnumerable<Aircraft>>> GetAircrafts()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<IEnumerable<Employee>>> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<IEnumerable<Team>>> GetMembers(string teamId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<IEnumerable<ServiceTask>>> GetTasksForAircraft(string aircraftId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<IEnumerable<Team>>> GetTeam(string teamId)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<IEnumerable<Team>>> GetTeams()
        {
            throw new NotImplementedException();
        }

        public Task<ResponseBase> Login(string password)
        {
            throw new NotImplementedException();
        }
    }
}
