using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Repositories.IRepositories;
using Weather.Core.Services;
using Weather.Core.Services.Infrastructure;
using Xunit;

namespace WeatherApp.Tests.ServicesTests
{
    public class WeatherServiceTests
    {
        [Fact]
        public void WeatherRepositoryConstructorTestGood()
        {
            IWeatherRepository weatherRepo;
            weatherRepo = Substitute.For<IWeatherRepository>();
            weatherRepo.GetCurrentWeatherByCity("Warsaw").Returns(new Weather.Core.Models.WeatherModel
            {
                Current = new Weather.Core.Models.CurrentWeather { Humidity = 4, Temp_c = 4 },
                Location = new Weather.Core.Models.Location { Country = "Poland", Name = "Warsaw" }
            });
            IWeatherService weatherService = new WeatherService(weatherRepo);
            var result=weatherService.GetCurrentWeather(new Weather.Core.Models.Requests.GetWeatherModel
            {
                City="Warsaw",
                Country="Poland"
            });
            Assert.Equal("Poland", result.location.country);
            Assert.Equal("Warsaw",result.location.city);
        }
    }
}
