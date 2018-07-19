using NSubstitute;
using System.Web.Mvc;
using Weather.Core.Models.Requests;
using Weather.Core.Services.Infrastructure;
using WeatherApp.FrontEnd.Controllers;
using WeatherApp.FrontEnd.Models;
using Xunit;

namespace WeatherApp.Tests.FrontEndControllersTests
{
    public class WeatherUIControllerTests
    {
        [Fact]
        public void WeatherUIControllerConstructorTest()
        {
            IWeatherService weatherService;
            weatherService = Substitute.For<IWeatherService>();
            WeatherUIController controller = new WeatherUIController(weatherService);
            Assert.IsType<WeatherUIController>(controller);
        }

        [Fact]
        public void CurrentWeatherTestGood()
        {
            IWeatherService weatherService;
            weatherService = Substitute.For<IWeatherService>();
            WeatherUIController controller = new WeatherUIController(weatherService);
            var res = controller.CurrentWeather();
            Assert.IsType<ViewResult>(res);
        }

        [Fact]
        public void CurrentWeatherPostFormTestGood()
        {
            var request = new GetWeatherModel
            {
                City = "Warsaw",
                Country = "Poland"
            };
            IWeatherService weatherService;
            weatherService = Substitute.For<IWeatherService>();
            weatherService.GetCurrentWeather(Arg.Any<GetWeatherModel>()).Returns(new Weather.Core.Models.Responses.CurrentWeatherResponseModel
            {
                humidity = 4,
                location = new Weather.Core.Models.Responses.ResponseLocation { city = "Warsaw", country = "Poland" },
                temperature = new Weather.Core.Models.Responses.ResponseTemperature { format = "test", value = 4 }
            });
            WeatherUIController controller = new WeatherUIController(weatherService);
            var res = controller.CurrentWeather(new GetCurrentWeather {
                City="Warsaw",
                Country="Poland"
            });
            var viewResult = res as ViewResult;
            var viewModel = viewResult.Model as GetCurrentWeather;
            Assert.Equal(4, viewModel.TemperatureValue);
        }
    }
}
