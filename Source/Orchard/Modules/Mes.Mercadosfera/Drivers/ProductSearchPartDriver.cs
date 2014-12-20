using Mes.Mercadosfera.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Mercadosfera.Drivers
{
    public class ProductSearchPartDriver : ContentPartDriver<ProductSearchPart>
    {
        protected override string Prefix
        {
            get { return "ProductSearch"; }
        }


        protected override DriverResult Display(ProductSearchPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_ProductSearchPart",
                             () => shapeHelper.Parts_ProductSearch(
                           Datos: ""));
        }
    }
}