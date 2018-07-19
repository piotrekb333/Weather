using CassiniDev;
using SpecsFor.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Http.SelfHost;
using WeatherApp.FrontEnd;
using WeatherApp.WebApi;
using WeatherApp.WebApi.Controllers;
using Xunit;

namespace WeatherApp.IntegrationTests.ApiControllers
{

    public class WeatherControllerTests
    {

        [Fact]
        public void GetCurrentWeatherJsonTest()
        {
            var config = new HttpSelfHostConfiguration("http://localhost:51583");
          
            config.Formatters.Clear();
            var jsonMediaTypeFormatter = new JsonMediaTypeFormatter { Indent = true };
            config.Formatters.Add(jsonMediaTypeFormatter);
            config.Formatters.Add(new FormUrlEncodedMediaTypeFormatter());
            WebApiConfig.Register(config);
            AutofacConfig.Initialize(config);
            using (HttpSelfHostServer server = new HttpSelfHostServer(config))
            {
                server.OpenAsync().Wait();
                var client = new HttpClient(server);
                var request = new HttpRequestMessage { RequestUri = new Uri("http://localhost:51583/api/weather/Poland/Warsaw") };
                request.Method = HttpMethod.Get;
                HttpResponseMessage response = client.SendAsync(request, new CancellationTokenSource().Token).Result;
                var str = response.Content.ReadAsStringAsync().Result;
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }

        }

    }
}
