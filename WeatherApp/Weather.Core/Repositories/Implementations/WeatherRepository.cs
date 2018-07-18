using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather.Core.Models;
using Weather.Core.Repositories.IRepositories;

namespace Weather.Core.Repositories.Implementations
{
    public class WeatherRepository : IWeatherRepository
    {
        IRestClient client;
        IRestRequest request;
        public WeatherRepository()
        {
            client = new RestClient(Helpers.Consts.WeatherApiUrl);
        }
        public WeatherRepository(IRestClient _client, IRestRequest _request)
        {
            client = _client;
            request = _request;
        }
        
        public WeatherModel GetCurrentWeatherByCity(string city)
        {            
            WeatherModel weather = null;
            if(request==null)
                request = new RestRequest(Helpers.Consts.WeatherGetCurrentUrl, Method.GET);
            request.AddUrlSegment("city", city);
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                weather = JsonConvert.DeserializeObject<WeatherModel>(response.Content);
            }
            response = null;
            return weather;
        }
    }
}