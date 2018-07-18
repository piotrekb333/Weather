using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Core.Models.Requests
{
    public class GetWeatherRequestModel
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}