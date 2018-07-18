using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models
{
    public class WeatherModel
    {
        public Location Location { get; set; }
        public CurrentWeather Current { get; set; }


    }
}