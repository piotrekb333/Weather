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
        public void WeatherRepositoryConstructorGood()
        {
            IWeatherRepository repository = new WeatherRepository();
            Assert.NotNull(repository);
        }

        [Fact]
        public void WeatherRepositoryConstructorWithParameterGood()
        {
            IRestClient resclient = new RestClient();
            IWeatherRepository repository = new WeatherRepository(resclient);
            Assert.NotNull(repository);
        }

        [Theory]
        [InlineData("Test","Test")]
        [InlineData("Test2", "Test2")]
        public void GetCurrentWeatherByCityGood(string city,string expected)
        {
            IRestClient restclient;
            restclient = Substitute.For<IRestClient>();
            IRestRequest request = new RestRequest();
            IRestResponse response = new RestResponse();
            response.StatusCode = System.Net.HttpStatusCode.OK;

            response.Content = JsonConvert.SerializeObject(new WeatherModel
            {
                Current =new CurrentWeather{ Humidity=3},
                Location =new Location {Name=city,Country="test" }
            });

            restclient.Execute(request).Returns(response);
            IWeatherRepository repository = new WeatherRepository(restclient);
            var result=repository.GetCurrentWeatherByCity(city);
            Assert.Equal(expected,result.Location.Name);
        }

        [Theory]
        [InlineData("Test", null)]
        [InlineData("Test2", null)]
        public void GetCurrentWeatherByCityNotGood(string city, string expected)
        {
            IRestClient restclient;
            restclient = Substitute.For<IRestClient>();
            IRestRequest request = new RestRequest();
            IRestResponse response = new RestResponse();
            response.StatusCode = System.Net.HttpStatusCode.BadRequest;

            response.Content = JsonConvert.SerializeObject(new WeatherModel
            {
                Current = new CurrentWeather { Humidity = 3 },
                Location = new Location { Name = city, Country = "test" }
            });

            restclient.Execute(request).Returns(response);
            IWeatherRepository repository = new WeatherRepository(restclient);
            var result = repository.GetCurrentWeatherByCity(city);
            Assert.Equal(expected, result.Location.Name);
        }
    }
}
