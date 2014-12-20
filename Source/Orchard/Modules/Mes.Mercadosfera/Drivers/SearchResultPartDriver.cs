using Mes.Mercadosfera.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Mercadosfera.Drivers
{
    public class SearchResultPartDriver : ContentPartDriver<SearchResultPart>
    {
        protected override string Prefix
        {
            get { return "SearchResult"; }
        }

        
        protected override DriverResult Display(SearchResultPart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("Parts_SearchResult",
                             () => shapeHelper.Parts_SearchResult(
                           Datos: ""));

        }
    }
}