
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
        //public MvcWebApp app;
        public WeatherUIControllerTests()
        {
            //app = new MvcWebApp();
            MvcAppConfig.SetupTestRun();
        }
        
        [Fact]
        public void DisplayCurrentWeatherPage()
        {
            //t.SetupTestRun();
            //  app = new MvcWebApp();
            MvcAppConfig.app.NavigateTo<WeatherUIController>(controller => controller.CurrentWeather());
            MvcAppConfig.app.UrlShouldMapTo<WeatherUIController>(c => c.CurrentWeather());

            /*
            app.NavigateTo<WeatherUIController>(controller => controller.CurrentWeather());
            app.UrlShouldMapTo<WeatherUIController>(c => c.CurrentWeather());

            

            app.NavigateTo<HomeController>(controller => controller.Index());
            app.FindFormFor<GetCurrentWeather>()
                //TODO: Eventually expose a fluent API like:
                .Field(m => m.Country).SetValueTo("Poland")
                .Field(m => m.City).SetValueTo("Warsaw")
                .Submit();
            var dd = app.Browser.PageSource;

            app.Browser.Close();
            */
            //app.Browser.Close();
            //t.DownTestRun();
            // MvcAppConfig t = new MvcAppConfig();
            //t.SetupTestRun();

            //app = new MvcWebApp();
            /*
           app.Browser.Navigate().GoToUrl("http://localhost:64592/users/Create");
           app.Browser.FindElementById().g.GoToUrl("http://localhost:64592/users/Create");
           */
            //var capabilities = new DesiredCapabilities();

            // var driver = new InternetExplorerDriver();
            // Navigate browser into register page 
            ////app.
            //var dd=app.AllText();
            //var lol = 4;
            //app.NavigateTo<HomeController>(con => con.Contact());

        }
        [Fact]
        public void DisplayCurrentWeatherPageStart()
        {
            //app = new MvcWebApp();

            MvcAppConfig.app.NavigateTo<HomeController>(controller => controller.Index());
            MvcAppConfig.app.UrlShouldMapTo<WeatherUIController>(c => c.CurrentWeather());
           // MvcAppConfig.app.Browser.Close();
            //t.DownTestRun();
        }

        [Fact]
        public void CurrentWeatherPostForm()
        {
            //  app = new MvcWebApp();

            MvcAppConfig.app.NavigateTo<HomeController>(controller => controller.Index());
            MvcAppConfig.app.FindFormFor<GetCurrentWeather>()
                //TODO: Eventually expose a fluent API like:
                .Field(m => m.Country).SetValueTo("Poland")
                .Field(m => m.City).SetValueTo("Warsaw")
                .Submit();
            MvcAppConfig.app.UrlShouldMapTo<WeatherUIController>(c => c.CurrentWeather());

            var dd = MvcAppConfig.app.Browser.PageSource;
           // MvcAppConfig.app.Browser.Close();

            //app.UrlShouldMapTo<WeatherUIController>(c => c.CurrentWeather());
            //var dd=app.Browser.FindElementById("td-country").Text;
            //app.Browser.Close();
        }
    }
}
