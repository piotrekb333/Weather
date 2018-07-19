using NSubstitute;
using System.Web.Http.Results;
using Weather.Core.Models.Requests;
using Weather.Core.Models.Responses;
using Weather.Core.Services.Infrastructure;
using WeatherApp.WebApi.Controllers;
using WeatherApp.WebApi.Models;
using Xunit;

namespace WeatherApp.Tests.ApiControllersTest
{
    public class WeatherControllerTests
    {
        [Fact]
        public void WeatherControllerConstructorTest()
        {
            IWeatherService weatherService;
            weatherService = Substitute.For<IWeatherService>();
            WeatherController controller = new WeatherController(weatherService);
            Assert.IsType<WeatherController>(controller);
        }
        [Fact]
        public void WeatherByCityTestGood()
        {
            var request = new GetWeatherModel
            {
                City = "Warsaw",
                Country = "Poland"
            };
            IWeatherService weatherService;
            weatherService=Substitute.For<IWeatherService>();
            weatherService.GetCurrentWeather(Arg.Any<GetWeatherModel>()).Returns(new Weather.Core.Models.Responses.CurrentWeatherResponseModel
            {
                humidity=4,
                location=new Weather.Core.Models.Responses.ResponseLocation { city="Warsaw",country="Poland"},
                temperature=new Weather.Core.Models.Responses.ResponseTemperature { format="test",value=4}
            });
            WeatherController controller = new WeatherController(weatherService);
            var res=controller.WeatherByCity(new GetWeatherRequest
            {
                City = "Warsaw",
                Country = "Poland"
            });
            Assert.IsType<OkNegotiatedContentResult<CurrentWeatherResponseModel>>(res);
        }
    }
}
