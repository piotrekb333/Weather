using Microsoft.Build.Utilities;
using SpecsFor.Mvc;
using System;
using WeatherApp.FrontEnd;


namespace WeatherApp.IntegrationTests
{

    public static class MvcAppConfig
    {
        public static SpecsForIntegrationHost _host;
        private static bool IsRun = false;
        public static MvcWebApp app;
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
            config.PostOperationDelay(new TimeSpan(0,0,0,4));
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

    }
}
