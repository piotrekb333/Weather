using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeatherApp.Models.Requests;
using WeatherApp.Models.Responses;
using WeatherApp.Services.Infrastructure;

namespace WeatherApp.Controllers
{
    public class WeatherController : ApiController
    {
        private readonly IWeatherService weatherService;
        public WeatherController(IWeatherService _weatherService)
        {
            weatherService = _weatherService;
        }
        [HttpGet]
        [Route("api/weather/{country}/{city}")]
        public IHttpActionResult WeatherByCity([FromUri]GetWeatherRequestModel model)
        {
            try
            {
                var result=weatherService.GetCurrentWeather(model);
                if (result == null)
                    return NotFound();
                return Ok<CurrentWeatherResponseModel>(result);
            }

            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
