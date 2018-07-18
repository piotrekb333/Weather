using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Weather.Core.Models.Requests;
using Weather.Core.Services.Infrastructure;
using WeatherApp.FrontEnd.Models;

namespace WeatherApp.FrontEnd.Controllers
{
    public class WeatherUIController : Controller
    {
        private readonly IWeatherService weatherService;
        public WeatherUIController(IWeatherService _weatherService)
        {
            weatherService = _weatherService;
        }
        // GET: WeatherUI
        public ActionResult CurrentWeather()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CurrentWeather(GetCurrentWeather model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.NotFound = false;
                return View(model);
            }
            var result = weatherService.GetCurrentWeather(new GetWeatherRequestModel
            {
                City =model.City,
                Country =model.Country
            });
            if (result != null)
            {
                model.Humidity = result.humidity;
                model.TemperatureFormat = result.temperature?.format;
                model.TemperatureValue = result.temperature?.value ?? 0;
            }
            else
            {
                ViewBag.NotFound = true;
            }
            return View(model);
        }
    }
}