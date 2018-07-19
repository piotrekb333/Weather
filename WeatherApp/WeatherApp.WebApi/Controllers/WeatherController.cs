using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Weather.Core.Models.Requests;
using Weather.Core.Models.Responses;
using Weather.Core.Services.Infrastructure;
using WeatherApp.WebApi.Models;

namespace WeatherApp.WebApi.Controllers
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
        public IHttpActionResult WeatherByCity([FromUri]GetWeatherRequest model)
        {
            try
            {
                var result=weatherService.GetCurrentWeather(new GetWeatherModel
                {
                    City=model.City,
                    Country=model.Country
                });
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
