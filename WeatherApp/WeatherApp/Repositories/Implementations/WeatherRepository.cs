using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WeatherApp.Models;
using WeatherApp.Repositories.IRepositories;

namespace WeatherApp.Repositories.Implementations
{
    public class WeatherRepository : IWeatherRepository
    {
        IRestClient client;
        public WeatherRepository()
        {
            client = new RestClient(Helpers.Consts.WeatherApiUrl);
        }
        public WeatherRepository(IRestClient _client)
        {
            client = _client;
        }
        
        public WeatherModel GetCurrentWeatherByCity(string city)
        {            
            WeatherModel weather = null;
            var request = new RestRequest(Helpers.Consts.WeatherGetCurrentUrl, Method.GET);
            request.AddUrlSegment("city", city); // replaces matching token in request.Resource
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                weather = JsonConvert.DeserializeObject<WeatherModel>(response.Content);
            }
            return weather;

        }
    }
}