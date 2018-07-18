using Weather.Core.Models.Requests;
using Weather.Core.Models.Responses;

namespace Weather.Core.Services.Infrastructure
{
    public interface IWeatherService
    {
        CurrentWeatherResponseModel GetCurrentWeather(GetWeatherRequestModel model);
    }
}
