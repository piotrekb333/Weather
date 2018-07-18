using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.Responses
{
    public class CurrentWeatherResponseModel
    {
        public ResponseLocation location { get; set; }
        public ResponseTemperature temperature { get; set; }
        public float humidity { get; set; }
    }
}