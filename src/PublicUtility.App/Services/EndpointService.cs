using Newtonsoft.Json;
using PublicUtility.App.Shared;
using PublicUtility.Domain.Commands.Core;
using PublicUtility.Domain.Commands.Inputs;
using PublicUtility.Domain.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace PublicUtility.App.Services
{
    public class EndpointService
    {
        private readonly HttpClient _http;

        public EndpointService()
        {
            _http = new HttpClient();
        }

        public IEnumerable<Endpoint> GetAll(string route)
        {
            HttpResponseMessage response = _http.GetAsync($"{Settings.API_URL}/{route}").Result;
            string content = response.Content.ReadAsStringAsync().Result;
            IEnumerable<Endpoint> result = JsonConvert.DeserializeObject<IEnumerable<Endpoint>>(content);

            return result;
        }

        public Endpoint GetBySerialNumber(string route)
        {
            HttpResponseMessage response = _http.GetAsync($"{Settings.API_URL}/{route}").Result;
            string content = response.Content.ReadAsStringAsync().Result;
           Endpoint result = JsonConvert.DeserializeObject<Endpoint>(content);

            return result;
        }

        public GenericCommandResult Post(string route, RegisterEndpointCommand command)
        {
            HttpResponseMessage response = _http.PostAsync(
                $"{Settings.API_URL}/{route}", 
                new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json")).Result;
            string content = response.Content.ReadAsStringAsync().Result;
            GenericCommandResult result = JsonConvert.DeserializeObject<GenericCommandResult>(content);

            return result;
        }

        public GenericCommandResult Put(string route, UpdateEndpointCommand command)
        {
            HttpResponseMessage response = _http.PutAsync(
                $"{Settings.API_URL}/{route}",
                new StringContent(JsonConvert.SerializeObject(command), Encoding.UTF8, "application/json")).Result;
            string content = response.Content.ReadAsStringAsync().Result;
            GenericCommandResult result = JsonConvert.DeserializeObject<GenericCommandResult>(content);

            return result;
        }

        public GenericCommandResult Delete(string route)
        {
            HttpResponseMessage response = _http.DeleteAsync($"{Settings.API_URL}/{route}").Result;
            string content = response.Content.ReadAsStringAsync().Result;
            GenericCommandResult result = JsonConvert.DeserializeObject<GenericCommandResult>(content);

            return result;
        }
    }
}
