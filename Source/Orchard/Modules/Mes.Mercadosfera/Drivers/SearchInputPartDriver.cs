using Mes.Mercadosfera.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Mercadosfera.Drivers
{
    public class SearchInputPartDriver : ContentPartDriver<SearchInputPart>
    {
        protected override string Prefix
        {
            get { return "SearchInput"; }
        }


        protected override DriverResult Display(SearchInputPart part, string displayType, dynamic shapeHelper)
        {
            return ContentShape("Parts_SearchInput",
                             () => shapeHelper.Parts_SearchInput(
                           Datos: ""));
        }
    }
}