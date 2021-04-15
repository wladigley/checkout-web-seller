using Microsoft.Owin.Hosting;
using Owin;
using System;
using System.Web.Http;

namespace checkout_web_local_api
{
    public class Startup
    {
        private static IDisposable diss;
        public void Configuration(IAppBuilder app)
        {
            // Configure Web API for self-host.
            //link for implementations:
            // https://forums.asp.net/t/2100905.aspx?attribute+routing+is+possible+with+self+host
            // https://docs.microsoft.com/en-us/aspnet/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
            name: "CheckoutWebSalesApi",
            routeTemplate: "api/{controller}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );
            app.UseWebApi(config);
        }
        public static void Run()
        {
            diss = WebApp.Start<Startup>("http://localhost:12345");
        }

        public static void Dispose()
        {
            diss.Dispose();
        }
    }
}
