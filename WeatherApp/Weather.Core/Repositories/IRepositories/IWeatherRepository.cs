using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.Core.Models;

namespace Weather.Core.Repositories.IRepositories
{
    public interface IWeatherRepository
    {
        WeatherModel GetCurrentWeatherByCity(string city);
    }
}
