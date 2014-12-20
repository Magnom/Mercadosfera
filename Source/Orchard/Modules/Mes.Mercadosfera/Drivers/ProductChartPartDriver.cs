using Mes.Mercadosfera.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Mercadosfera.Drivers
{
    public class ProductChartPartDriver : ContentPartDriver<ProductChartPart>
    {
        protected override string Prefix
        {
            get { return "ProductChart"; }
        }


        protected override DriverResult Display(ProductChartPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_ProductChart",
                             () => shapeHelper.Parts_ProductChart(
                           Datos: ""));
        }
    }
}