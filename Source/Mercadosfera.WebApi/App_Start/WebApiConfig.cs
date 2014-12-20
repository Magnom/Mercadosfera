using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Mercadosfera.WebApi
{
    public static class WebApiConfig
    {
        public class OptionsHttpMessageHandler : DelegatingHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(
                HttpRequestMessage request, CancellationToken cancellationToken)
            {
                if (request.Method == HttpMethod.Options)
                {
                    return Task.Factory.StartNew(() =>
                    {
                        var resp = new HttpResponseMessage(HttpStatusCode.OK);

                        return resp;
                    });
                }
                return base.SendAsync(request, cancellationToken);
            }
        }

        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.PreserveReferencesHandling =
                Newtonsoft.Json.PreserveReferencesHandling.Objects;

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            GlobalConfiguration.Configuration.MessageHandlers.Add(new OptionsHttpMessageHandler());
        }
    }
}
