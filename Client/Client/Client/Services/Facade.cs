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

        public async Task<ResponseData<IEnumerable<Team>>> AddMemberToTeam(string teamId)
        {
            var responseData = new ResponseData<IEnumerable<Team>>()
            {
                HasBeenSuccessful = false
            };
            var result = await this.apiWrapper.AddMemberToTeam(teamId);
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
            responseData.HasBeenSuccessful = false;
            responseData.Content = null;
            responseData.Error = "Internal server Error";
            return responseData;

        }

        public async Task<ResponseBase> CreateTask(string aircraftId, string teamId, string description)
        {
            var responseData = new ResponseBase
            {
                HasBeenSuccessful = false
            };

            var result = await this.apiWrapper.CreateTask(aircraftId, teamId, description);
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
        }

        public async Task<ResponseData<IEnumerable<Aircraft>>> GetAircrafts()
        {
            var responseData = new ResponseData<IEnumerable<Aircraft>>()
            {
                HasBeenSuccessful = false
            };
            var result = await this.apiWrapper.GetAircrafts();
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var deserializedContent = JsonConvert.DeserializeObject<ResponseData<IEnumerable<Aircraft>>>(content);

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
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    responseData.HasBeenSuccessful = false;
                    responseData.Content = null;
                    responseData.Error = "Deserialization Error";
                    return responseData;
                }
            }
            responseData.HasBeenSuccessful = false;
            responseData.Content = null;
            responseData.Error = "Internal server Error";
            return responseData;

        }

        public async Task<ResponseData<IEnumerable<Employee>>> GetEmployees()
        {
            var responseData = new ResponseData<IEnumerable<Employee>>()
            {
                HasBeenSuccessful = false
            };
            var result = await this.apiWrapper.GetEmployees();
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var deserializedContent = JsonConvert.DeserializeObject<ResponseData<IEnumerable<Employee>>>(content);

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
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    responseData.HasBeenSuccessful = false;
                    responseData.Content = null;
                    responseData.Error = "Deserialization Error";
                    return responseData;
                }
            }
            responseData.HasBeenSuccessful = false;
            responseData.Content = null;
            responseData.Error = "Internal server Error";
            return responseData;

        }

        public async Task<ResponseData<IEnumerable<Team>>> GetMembers(string teamId)
        {
            var responseData = new ResponseData<IEnumerable<Team>>()
            {
                HasBeenSuccessful = false
            };
            var result = await this.apiWrapper.GetMembers(teamId);
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
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
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    responseData.HasBeenSuccessful = false;
                    responseData.Content = null;
                    responseData.Error = "Deserialization Error";
                    return responseData;
                }
            }
            
            responseData.HasBeenSuccessful = false;
            responseData.Content = null;
            responseData.Error = "Internal server Error";
            return responseData;
            
        }

        public async Task<ResponseData<IEnumerable<ServiceTask>>> GetTasksForAircraft(string aircraftId)
        {
            var responseData = new ResponseData<IEnumerable<ServiceTask>>()
            {
                HasBeenSuccessful = false
            };
            var result = await this.apiWrapper.GetTasksForAircraft(aircraftId);
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var deserializedContent = JsonConvert.DeserializeObject<ResponseData<IEnumerable<ServiceTask>>>(content);

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
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    responseData.HasBeenSuccessful = false;
                    responseData.Content = null;
                    responseData.Error = "Deserialization Error";
                    return responseData;
                }
            }

            responseData.HasBeenSuccessful = false;
            responseData.Content = null;
            responseData.Error = "Internal server Error";
            return responseData;
        }

        public async Task<ResponseData<IEnumerable<Team>>> GetTeam(string teamId)
        {
            var responseData = new ResponseData<IEnumerable<Team>>()
            {
                HasBeenSuccessful = false
            };
            var result = await this.apiWrapper.GetTeam(teamId);
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
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
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    responseData.HasBeenSuccessful = false;
                    responseData.Content = null;
                    responseData.Error = "Deserialization Error";
                    return responseData;
                }
            }

            responseData.HasBeenSuccessful = false;
            responseData.Content = null;
            responseData.Error = "Internal server Error";
            return responseData;
        }

        public async Task<ResponseData<IEnumerable<Team>>> GetTeams()
        {
            var responseData = new ResponseData<IEnumerable<Team>>()
            {
                HasBeenSuccessful = false
            };
            var result = await this.apiWrapper.GetTeams();
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
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
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    responseData.HasBeenSuccessful = false;
                    responseData.Content = null;
                    responseData.Error = "Deserialization Error";
                    return responseData;
                }
            }

            responseData.HasBeenSuccessful = false;
            responseData.Content = null;
            responseData.Error = "Internal server Error";
            return responseData;
        }

        public async Task<ResponseBase> Login(string password)
        {
            var responseData = new ResponseData<IEnumerable<Team>>()
            {
                HasBeenSuccessful = false
            };
            var result = await this.apiWrapper.Login(password);
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
        }
    }
}
