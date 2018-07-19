using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Weather.Core.Helpers
{
    public class Consts
    {
        public const string WeatherApiUrl = "http://api.apixu.com/v1/";
        public const string WeatherGetCurrentEndPoint = @"current.json?key=51577d8da8e247c0979131855181807&q={city}";
    }
}