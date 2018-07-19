using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Weather.Core.Models;
using Weather.Core.Models.Requests;
using Weather.Core.Models.Responses;
using Weather.Core.Repositories.IRepositories;
using Weather.Core.Services.Infrastructure;

namespace Weather.Core.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository weatherRepository;
        public WeatherService(IWeatherRepository _weatherRepository)
        {
            weatherRepository = _weatherRepository;
        }

        public CurrentWeatherResponseModel GetCurrentWeather(GetWeatherModel model)
        {
            WeatherModel weather=weatherRepository.GetCurrentWeatherByCity(model.City);
            if (weather == null)
                return null;
            if (model.Country.ToLower() != weather.Location.Country.ToLower())
                return null;
            CurrentWeatherResponseModel responseWeather = new CurrentWeatherResponseModel{
                humidity=weather.Current.Humidity,
                location=new ResponseLocation { city=weather.Location.Name,country=weather.Location.Country},
                temperature=new ResponseTemperature { format= "Celsius",value=weather.Current.Temp_c }
            };
            return responseWeather;
        }

    }
}