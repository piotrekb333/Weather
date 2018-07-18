using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Repositories.IRepositories
{
    public interface IWeatherRepository
    {
        WeatherModel GetCurrentWeatherByCity(string city);
    }
}
