using WeatherApp.FrontEnd.Controllers;
using WeatherApp.FrontEnd.Models;
using WeatherApp.IntegrationTests;
using Xunit;

namespace WeatherApp.BDDTests
{
    public class WeatherTests
    {
        public WeatherTests()
        {
            MvcAppConfig.SetupTestRun();
        }
        [Theory]
        [InlineData("Poland", "Warsaw")]
        [InlineData("Poland", "Gdansk")]
        [InlineData("Germany", "Berlin")]
        public void CurrentWeatherBDDTests(string country,string city)
        {
            MvcAppConfig.app.NavigateTo<HomeController>(controller => controller.Index());
            MvcAppConfig.app.FindFormFor<GetCurrentWeather>()
                .Field(m => m.Country).SetValueTo(country)
                .Field(m => m.City).SetValueTo(city)
                .Submit();
            var cityReturned = MvcAppConfig.app.Browser.FindElementById("td-city").Text;
            var countryReturned = MvcAppConfig.app.Browser.FindElementById("td-country").Text;
            Assert.Equal(country, countryReturned);
            Assert.Equal(city, cityReturned);
        }
    }
}
