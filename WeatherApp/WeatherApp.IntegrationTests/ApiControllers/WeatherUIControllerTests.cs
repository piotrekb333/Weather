
using SpecsFor.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.FrontEnd.Controllers;
using WeatherApp.FrontEnd.Models;
using Xunit;

namespace WeatherApp.IntegrationTests.ApiControllers
{
    public class WeatherUIControllerTests
    {
        public WeatherUIControllerTests()
        {
            MvcAppConfig.SetupTestRun();
        }
        
        [Fact]
        public void DisplayCurrentWeatherPage()
        {

            MvcAppConfig.app.NavigateTo<WeatherUIController>(controller => controller.CurrentWeather());
            MvcAppConfig.app.UrlShouldMapTo<WeatherUIController>(c => c.CurrentWeather());
        }
        [Fact]
        public void DisplayCurrentWeatherPageStart()
        {
            MvcAppConfig.app.NavigateTo<HomeController>(controller => controller.Index());
            MvcAppConfig.app.UrlShouldMapTo<WeatherUIController>(c => c.CurrentWeather());

        }

        [Fact]
        public void CurrentWeatherPostForm()
        {
            MvcAppConfig.app.NavigateTo<HomeController>(controller => controller.Index());
            MvcAppConfig.app.FindFormFor<GetCurrentWeather>()
                .Field(m => m.Country).SetValueTo("Poland")
                .Field(m => m.City).SetValueTo("Warsaw")
                .Submit();
            MvcAppConfig.app.UrlShouldMapTo<WeatherUIController>(c => c.CurrentWeather());
        }
    }
}
