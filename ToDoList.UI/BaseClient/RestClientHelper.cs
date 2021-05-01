using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using System.Collections.Generic;
using System.Configuration;
using ToDoList.UI.Models.Request;
using ToDoList.UI.Models.Response;

namespace ToDoList.UI.BaseClient
{
    public class RestClientHelper
    {
        private readonly string _baseUrl;
        public RestClientHelper()
        {
            _baseUrl = ConfigurationManager.AppSettings["toDoAPIUrl"];

        }
        JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        public AddToDoResponse AddToDo(AddToDoRequest addToDoRequest)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/todo", Method.POST);
            request.AddHeader("Accept", "application/json");
            string jsonObject = JsonConvert.SerializeObject(addToDoRequest, Formatting.Indented, jsonSerializerSettings);
            request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new AddToDoResponse { IsError = true, ErrorMessage = response.Content };

            var addedId = JsonConvert.DeserializeObject<int>(response.Content);
            return new AddToDoResponse
            {
                Id = addedId
            };
        }
        public UpdateToDoResponse UpdateToDo(UpdateToDoRequest updateToDoRequest)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/todo", Method.PUT);
            request.AddHeader("Accept", "application/json");
            string jsonObject = JsonConvert.SerializeObject(updateToDoRequest, Formatting.Indented, jsonSerializerSettings);
            request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new UpdateToDoResponse { IsError = true, ErrorMessage = response.Content };

            return new UpdateToDoResponse();
        }
        public DeleteToDoResponse DeleteToDo(DeleteToDoRequest deleteToDoRequest)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/todo", Method.DELETE);
            request.AddHeader("Accept", "application/json");
            string jsonObject = JsonConvert.SerializeObject(deleteToDoRequest, Formatting.Indented, jsonSerializerSettings);
            request.AddParameter("application/json", jsonObject, ParameterType.RequestBody);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new DeleteToDoResponse { IsError = true, ErrorMessage = response.Content };

            return new DeleteToDoResponse();
        }
        public GetToDoInfoResponse GetToDo(int id)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/todo", Method.GET, DataFormat.Json);
            request.AddParameter("id", id);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new GetToDoInfoResponse { IsError = true, ErrorMessage = response.Content };

            var getToDoResponse = JsonConvert.DeserializeObject<GetToDoInfoResponse>(response.Content);
            return getToDoResponse;
        }
        public List<GetToDoInfoResponse> GetToDoList()
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest("api/todo/gettodolist", Method.GET, DataFormat.Json);
            var response = client.Execute(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                return new List<GetToDoInfoResponse>();

            var getToDoListResponse = JsonConvert.DeserializeObject<List<GetToDoInfoResponse>>(response.Content);
            return getToDoListResponse;
        }
    }
}