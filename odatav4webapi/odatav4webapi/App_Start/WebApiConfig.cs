using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using odatav4webapi.Models;

namespace odatav4webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Kupac>("Okupacs");
            builder.EntitySet<Grad>("Grads");
            builder.EntitySet<Drzava>("Drzavas");
            builder.EntitySet<Kategorija>("Kategorijas");
            builder.EntitySet<Potkategorija>("Potkategorijas");
            builder.EntitySet<Komercijalist>("Komercijalists");
            builder.EntitySet<KreditnaKartica>("KreditnaKartica>s");
            builder.EntitySet<Proizvod>("Proizvods");
            builder.EntitySet<Racun>("Racuns");
            builder.EntitySet<Stavka>("Stavkas");

            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.JsonFormatter.Indent = false;
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }
    }
}
