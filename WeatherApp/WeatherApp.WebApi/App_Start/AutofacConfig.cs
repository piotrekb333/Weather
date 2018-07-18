using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using Weather.Core.Repositories.Implementations;
using Weather.Core.Repositories.IRepositories;
using Weather.Core.Services;
using Weather.Core.Services.Infrastructure;

namespace WeatherApp.WebApi
{
    public class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<WeatherRepository>()
                   .As<IWeatherRepository>()
                   .InstancePerRequest();
            builder.RegisterType<WeatherService>()
                  .As<IWeatherService>()
                  .InstancePerRequest();
            Container = builder.Build();

            return Container;
        }

    }
}