using Microsoft.Build.Utilities;
using SpecsFor.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.FrontEnd;
using WeatherApp.WebApi;

namespace WeatherApp.IntegrationTests
{

    public static class MvcAppConfig
    {
        public static SpecsForIntegrationHost _host;
        private static bool IsRun = false;
        private static bool IsApiRun = false;
        public static MvcWebApp app;
        public static MvcWebApp appApi;
        public static void SetupTestRun()
        {
            if (IsRun)
                return;
            string msBuild =  ToolLocationHelper.GetPathToBuildToolsFile("msbuild.exe", "16.0");
            var config = new SpecsForMvcConfig();
            config.UseIISExpress()
            .With(Project.Named("WeatherApp.FrontEnd"))
            .UseMSBuildExecutableAt(msBuild);
            config.BuildRoutesUsing(r => RouteConfig.RegisterRoutes(r));
            config.UseBrowser(BrowserDriver.InternetExplorer);  
            _host = new SpecsForIntegrationHost(config);
            _host.Start();
            app = new MvcWebApp();
            
            IsRun = true;
        }

        public static void DownTestRun()
        {
            _host.Shutdown();
            IsRun = false;
        }

        public static void SetupApiTestRun()
        {
            if (IsRun)
                return;
            string msBuild = ToolLocationHelper.GetPathToBuildToolsFile("msbuild.exe", "16.0");
            var config = new SpecsForMvcConfig();
            config.UseIISExpress()
            .With(Project.Named("WeatherApp.WebApi"))
            .UseMSBuildExecutableAt(msBuild);
            //config.BuildRoutesUsing(r => WebApiConfig.Register(r));
            config.UseBrowser(BrowserDriver.InternetExplorer);
            _host = new SpecsForIntegrationHost(config);
            _host.Start();
            app = new MvcWebApp();

            IsRun = true;
        }

        public static void DownApiTestRun()
        {
            _host.Shutdown();
            IsRun = false;
        }
    }
}
