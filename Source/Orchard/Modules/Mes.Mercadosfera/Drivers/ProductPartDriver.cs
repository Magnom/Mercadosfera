using Mes.Mercadosfera.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Mercadosfera.Drivers
{
    public class ProductPartDriver : ContentPartDriver<ProductPart>
    {
        protected override string Prefix
        {
            get { return "Product"; }
        }

        
        protected override DriverResult Display(ProductPart part, string displayType, dynamic shapeHelper)
        {
            
            return ContentShape("Parts_Product",
                             () => shapeHelper.Parts_Product(
                           Model: part));

        }
    }
}