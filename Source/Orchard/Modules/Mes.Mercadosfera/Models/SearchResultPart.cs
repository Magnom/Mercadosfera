using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mes.Mercadosfera.Models
{
    
    public class SearchResultPart : ContentPart<SearchResultRecord>
    {
        
        /*public string webserviceURL
        {
            get { return Record.webserviceURL; }
            set { Record.webserviceURL = value; }
        }*/

    }
    
    public class SearchResultRecord : ContentPartRecord
    {
        //public string webserviceURL { get; set; }
    }
    

}