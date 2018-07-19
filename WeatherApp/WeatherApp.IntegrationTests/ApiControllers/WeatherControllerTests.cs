using CassiniDev;
using SpecsFor.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using WeatherApp.FrontEnd;
using Xunit;

namespace WeatherApp.IntegrationTests.ApiControllers
{

    public class WeatherControllerTests
    {
        public WeatherControllerTests()
        {
        }

        [Fact]
        public void GetCurrentWeatherJson()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage { RequestUri = new Uri(MvcAppConfig.APIUrl+"api/weather/Poland/"+"Warsaw") };
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Method = HttpMethod.Get;
            HttpResponseMessage response = client.SendAsync(request, new CancellationTokenSource().Token).Result;
            var str=response.Content.ReadAsStringAsync().Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

    }
}
