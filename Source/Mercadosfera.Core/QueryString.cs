using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Mercadosfera.Core
{
    public class QueryString
    {
        public NameValueCollection Qs { get; set; }
        
        public QueryString(string qsString)
        {
            NameValueCollection qscoll = HttpUtility.ParseQueryString(qsString);
            Qs = qscoll;
        }

        public string Get (string key, string defaultValue) {
            if (Qs.AllKeys.Contains(key))
            {
                return Qs[key].ToString();
            }
            else {
                return defaultValue;
            }
        }

        public string Get(string key)
        {            
                return Get(key,"");            
        }

        public QueryString()
        {
            NameValueCollection qscoll = HttpUtility.ParseQueryString(HttpContext.Current.Request.RawUrl.Replace("?","?&"));
            Qs = qscoll;
        }
    }
}
