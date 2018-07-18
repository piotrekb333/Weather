using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WeatherApp.Models.Responses
{
    public class ResponseTemperature
    {
        public string format { get; set; }
        public float value { get; set; }
    }
}