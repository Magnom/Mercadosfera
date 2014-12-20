using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Mes.Mercadosfera
{
    public class Routes : IRouteProvider
    {

        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (RouteDescriptor routeDescriptor in GetRoutes())
            {
                routes.Add(routeDescriptor);
            }
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {


            return new[] {
                new RouteDescriptor {
                    Priority = 5,
                    Route = new Route(
                        "Vendedores", // url
                        new RouteValueDictionary {
                            {"area", "Mes.Mercadosfera"},
                            {"controller", "Vendedores"},
                            {"action", "Registro"},
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Mes.Mercadosfera"}
                        },
                        new MvcRouteHandler())
                }
            };

        }
    }
}