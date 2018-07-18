using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Weather.Core.Repositories.Implementations;
using Weather.Core.Repositories.IRepositories;
using Weather.Core.Services;
using Weather.Core.Services.Infrastructure;

namespace WeatherApp.FrontEnd.App_Start
{
    public static class AutofacConfig
    {

        public static void RegisterServices()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<WeatherRepository>()
                    .As<IWeatherRepository>()
                    .InstancePerRequest();
            builder.RegisterType<WeatherService>()
                   .As<IWeatherService>()
                   .InstancePerRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}