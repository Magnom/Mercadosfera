using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Mercadosfera.Models
{
    public class CalendarPart : ContentPart<CalendarPartRecord>
    {
        public int IdCalendar
        {
            get { return Record.IdCalendar; }
            set { Record.IdCalendar = value; }
        }
    }

    public class CalendarPartRecord : ContentPartRecord
    {
        
        public virtual int IdCalendar { get; set; }
        
    }


}