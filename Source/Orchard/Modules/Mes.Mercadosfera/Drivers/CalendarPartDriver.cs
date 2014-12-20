using Mes.Mercadosfera.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Mercadosfera.Drivers
{
    public class CalendarPartDriver : ContentPartDriver<CalendarPart>
    {
        protected override string Prefix
        {
            get { return "Calendar"; }
        }

    
        protected override DriverResult Display(CalendarPart part, string displayType, dynamic shapeHelper)
        {
           
            return ContentShape("Parts_CalendarPart",
                             () => shapeHelper.Parts_Calendar(
                           Datos: ""));
        }
    }
}