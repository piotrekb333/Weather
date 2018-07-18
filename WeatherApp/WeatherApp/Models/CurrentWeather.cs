using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class CurrentWeather
    {
        public float Temp_c { get; set; }
        public float Temp_f { get; set; }
        public float Humidity { get; set; }
    }
}