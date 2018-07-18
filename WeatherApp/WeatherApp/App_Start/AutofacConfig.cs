using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using WeatherApp.Repositories.Implementations;
using WeatherApp.Repositories.IRepositories;
using WeatherApp.Services;
using WeatherApp.Services.Infrastructure;

namespace WeatherApp.App_Start
{
    public class AutofacConfig
    {
       // private static IContainer Container { get; set; }
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
            //Register your Web API controllers.  
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<WeatherRepository>()
                   .As<IWeatherRepository>()
                   .InstancePerRequest();
            builder.RegisterType<WeatherService>()
                  .As<IWeatherService>()
                  .InstancePerRequest();
            /*
            builder.RegisterGeneric(typeof(GenericRepository<>))
                   .As(typeof(IGenericRepository<>))
                   .InstancePerRequest();
                   */
            //Set the dependency resolver to be Autofac.  
            Container = builder.Build();

            return Container;
        }

    }
}