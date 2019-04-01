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


        public async Task<ResponseBase> AddMemberToTeam(List<Employee> newEmployees,string teamId)


        {
            // Resnpose Data object intiialise
            var responseData = new ResponseData<IEnumerable<Team>>()
            {
                HasBeenSuccessful = false
            };

            // Create a new Add Member Request
            var addMemberReq = new AddMemberRequest();
            addMemberReq.NewMembers = newEmployees;
            addMemberReq.TeamId = teamId;
            // Call the wrapper with the newly created add member request body
            var result = await this.apiWrapper.AddMemberToTeam(addMemberReq);
            // Content - the response we get from the back end
            string content = await result.Content.ReadAsStringAsync();
            // Compare the satus code we receive with the constant OK (201)
            if(result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    // If OK, deserialise the content using the JSON Library to a Team Object
                    var deserializedContent = JsonConvert.DeserializeObject<ResponseData<IEnumerable<Team>>>(content);

                    // If deserialisation failed or it produced no content
                    if (!deserializedContent.HasBeenSuccessful || !deserializedContent.Content.Any())
                    {
                        // Create the Reponse Data with failed, no content, Error message
                        responseData.HasBeenSuccessful = false;
       
                        responseData.Error = "Internal Server Error";
                        return responseData;
                    }
                    // If deserialisation succeeded, create reseonse dat with succeded, content received, no Error message
                    responseData.HasBeenSuccessful = true;
                
                    responseData.Error = null;
                    return responseData;
                }
                catch(Exception e)
                {
                    // Catch a internal problem and print it
                    Console.WriteLine(e.StackTrace);
                    // Create the Reponse Data with failed, no content, Error message
                    responseData.HasBeenSuccessful = false;
          
                    responseData.Error = "Deserialization Error";
                    return responseData;
                }
            }
            // If anything else goes wrong - Create the Reponse Data with failed, no content, Error message
            responseData.HasBeenSuccessful = false;

            responseData.Error = "Internal server Error";
            return responseData;
        }

        // Create a new Task
        public async Task<ResponseBase> CreateTask(string aircraftId, string teamId, string description)
        {
            // Resnpose Data object intiialise
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

        // Get all the aircrafts
        public async Task<ResponseData<IEnumerable<Aircraft>>> GetAircrafts()
        {
            // Resnpose Data object intiialise
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
        
        // Get all the Tasks for one Aircraft
        public async Task<ResponseData<IEnumerable<ServiceTask>>> GetAircraftTasks(string aircraftId)
        {
            // Resnpose Data object intiialise
            var responseData = new ResponseData<IEnumerable<ServiceTask>>()
            {
                HasBeenSuccessful = false
            };
            var req = new GetTasksForAircraftRequest();
            req.AircraftId = aircraftId;
            var result = await this.apiWrapper.GetTasksForAircraft(req);
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

        // Get all the Employees
        public async Task<ResponseData<IEnumerable<Employee>>> GetEmployees()
        {
            // Resnpose Data object intiialise
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

        // Get all the team Members for a Team ID
        public async Task<ResponseData<IEnumerable<Employee>>> GetTeamMembers(string teamId)
        {
            // Resnpose Data object intiialise
            var responseData = new ResponseData<IEnumerable<Employee>>()
            {
                HasBeenSuccessful = false
            };
            var req = new GetTeamMembersRequest();
            req.teamId = teamId;
            var result = await this.apiWrapper.GetTeamMembers(req);
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var deserializedContent = JsonConvert.DeserializeObject<ResponseData<IEnumerable<Employee>>>(content);

                    if (!deserializedContent.HasBeenSuccessful || deserializedContent.Content==null)
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

        // Get all the Tasks for an Aircraft
        public async Task<ResponseData<IEnumerable<ServiceTask>>> GetTasksForAircraft(string aircraftId)
        {
            // Resnpose Data object intiialise
            var responseData = new ResponseData<IEnumerable<ServiceTask>>()
            {
                HasBeenSuccessful = false
            };
            var getTasksForAircraftReq = new GetTasksForAircraftRequest();
            getTasksForAircraftReq.AircraftId = aircraftId;
            var result = await this.apiWrapper.GetTasksForAircraft(getTasksForAircraftReq);
            string content = await result.Content.ReadAsStringAsync();
            if (result.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var deserializedContent = JsonConvert.DeserializeObject<ResponseData<IEnumerable<ServiceTask>>>(content);

                    if (!deserializedContent.HasBeenSuccessful || deserializedContent.Content == null)
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

        // Get the team based on a Team ID
        public async Task<ResponseData<IEnumerable<Team>>> GetTeam(string teamId)
        {
            // Resnpose Data object intiialise
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

                    if (!deserializedContent.HasBeenSuccessful || deserializedContent.Content == null)
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

        // Get all the Teams
        public async Task<ResponseData<IEnumerable<Team>>> GetTeams()
        {
            // Resnpose Data object intiialise
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

                    if (!deserializedContent.HasBeenSuccessful || deserializedContent.Content == null)
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

        // Login
        public async Task<ResponseData<User>> Login(string password)
        {
            // Resnpose Data object intiialise
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

        // Mark a Task as Completed
        public async Task<ResponseBase> MarkTaskAsCompleted(string taskToBeCompleted)
        {
            // Resnpose Base object intiialise
            var responseData = new ResponseBase
            {
                HasBeenSuccessful = false
            };

            var serviceTaskReq = new MarkTaskAsCompletedRequest();
            serviceTaskReq.TaskId = taskToBeCompleted;

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

        // Assign a Task to an Aircraft
        public async Task<ResponseBase> AssignTaskToAircraft(string aircraftId, string title, string description, string status)
        {
            // Resnpose Base object intiialise
            var responseData = new ResponseBase
            {
                HasBeenSuccessful = false
            };

            var serviceTaskReq = new AssignTaskRequest();
            serviceTaskReq.AircraftId = aircraftId;
            serviceTaskReq.Title = title;
            serviceTaskReq.Description = description;
            serviceTaskReq.Status = status;
            var result = await this.apiWrapper.AssignTaskToAircraft(serviceTaskReq);
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

        // Assign a team to an Aircraft
        public async Task<ResponseBase> AssignTeamToAircraft(string aircraftId, string teamId)
        {
            // Resnpose Base object intiialise
            var responseData = new ResponseBase
            {
                HasBeenSuccessful = false
            };

            var serviceTeamReq = new AssignTeamRequest();
            serviceTeamReq.AircraftId = aircraftId;
            serviceTeamReq.TeamId = teamId;
            var result = await this.apiWrapper.AssignTeamToAircraft(serviceTeamReq);
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
