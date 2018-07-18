using WeatherApp.Models.Requests;
using WeatherApp.Models.Responses;

namespace WeatherApp.Services.Infrastructure
{
    public interface IWeatherService
    {
        CurrentWeatherResponseModel GetCurrentWeather(GetWeatherRequestModel model);
    }
}
