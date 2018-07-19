using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.WebApi.Models
{
    public class GetWeatherRequest
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}