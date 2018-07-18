using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherApp.FrontEnd.Models
{
    public class GetCurrentWeather
    {
        [Required(ErrorMessage ="Field City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Field Country is required")]
        public string Country { get; set; }

        public string TemperatureFormat { get; set; }
        public float TemperatureValue { get; set; }
        public float Humidity { get; set; }
    }
}