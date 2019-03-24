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
            var addMemberReq = new AddMemberRequest();
            addMemberReq.TeamId = teamId;
            var result = await this.apiWrapper.AddMemberToTeam(addMemberReq);
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
            var createTaskReq = new CreateTaskRequest();
            createTaskReq.AircraftId = aircraftId;
            createTaskReq.TeamId = teamId;
            createTaskReq.Description = description;
            var result = await this.apiWrapper.CreateTask(createTaskReq);
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
            var getMembersReq = new GetMembersRequest();
            getMembersReq.EmployeeId.Add(teamId);
            var result = await this.apiWrapper.GetMembers(getMembersReq);
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
            var getTasksForAircraftReq = new GetTasksForAircraftRequest();
            var newAircraft = new Aircraft();
            newAircraft.ID = aircraftId;
            getTasksForAircraftReq.GetTasksForAircraft.Add(newAircraft);
            var result = await this.apiWrapper.GetTasksForAircraft(getTasksForAircraftReq);
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
            var newTeamObj = new Team();
            newTeamObj.ID = teamId;
            var getTeamReq = new GetTeamRequest();
            getTeamReq.GetTeam = newTeamObj;
            var result = await this.apiWrapper.GetTeam(getTeamReq);
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

        public async Task<ResponseData<User>> Login(string password)
        {
            var responseData = new ResponseData<User>()
            {
                HasBeenSuccessful = false
            };

            var loginReq = new LoginRequest();
            loginReq.Password = password;
            var result = await this.apiWrapper.Login(loginReq);
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var deserializedContent = JsonConvert.DeserializeObject<ResponseData<User>>(content);
                    if (!deserializedContent.HasBeenSuccessful || deserializedContent.Error != null)
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
            responseData.Error = "Internal Error" + result.StatusCode.ToString();
            return responseData;
        }

        public async Task<ResponseBase> MarkTaskAsCompleted(ServiceTask taskToBeCompleted)
        {
            var responseData = new ResponseBase
            {
                HasBeenSuccessful = false
            };

            var serviceTaskReq = new TaskRequest();
            serviceTaskReq.Task = taskToBeCompleted;

            var result = await this.apiWrapper.MarkTaskAsCompleted(serviceTaskReq);
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
