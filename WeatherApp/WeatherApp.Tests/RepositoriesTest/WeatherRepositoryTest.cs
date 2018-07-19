using Newtonsoft.Json;
using NSubstitute;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Models;
using Weather.Core.Repositories.Implementations;
using Weather.Core.Repositories.IRepositories;
using Xunit;

namespace WeatherApp.Tests.RepositoriesTest
{
    public class WeatherRepositoryTest
    {

        [Fact]
        public void WeatherRepositoryConstructorTestGood()
        {
            IWeatherRepository repository = new WeatherRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void WeatherRepositoryConstructorWithParameterTestGood()
        {
            IRestClient resclient = new RestClient();
            IRestRequest request = new RestRequest();
            IWeatherRepository repository = new WeatherRepository(resclient, request);
            Assert.NotNull(repository);
        }

        [Fact]
        public void GetCurrentWeatherByCityTestGood()
        {
            IRestClient restclient;
            restclient = Substitute.For<IRestClient>();
            IRestRequest request = new RestRequest();
            IRestResponse response = new RestResponse();
            response.StatusCode = System.Net.HttpStatusCode.OK;

            response.Content = JsonConvert.SerializeObject(new WeatherModel
            {
                Current =new CurrentWeather{ Humidity=3},
                Location =new Location {Name="test",Country="test" }
            });

            restclient.Execute(request).Returns(response);
            IWeatherRepository repository = new WeatherRepository(restclient, request);
            var result=repository.GetCurrentWeatherByCity("test");
            Assert.Equal("test",result.Location.Name);
        }

        [Fact]
        public void GetCurrentWeatherByCityTestNotGood()
        {
            IRestClient restclient;
            restclient = Substitute.For<IRestClient>();
            IRestRequest request = new RestRequest();
            IRestResponse response = new RestResponse();
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;

            response.Content = JsonConvert.SerializeObject(new WeatherModel
            {
                Current = new CurrentWeather { Humidity = 3 },
                Location = new Location { Name = "test", Country = "test" }
            });

            restclient.Execute(request).Returns(response);
            IWeatherRepository repository = new WeatherRepository(restclient, request);
            var result = repository.GetCurrentWeatherByCity("test");
            Assert.Null(result);
        }
    }
}
