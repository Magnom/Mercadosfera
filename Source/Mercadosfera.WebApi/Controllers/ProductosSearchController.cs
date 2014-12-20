using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Mercadosfera.Data;
using Mercadosfera.Core;

namespace Mercadosfera.WebApi.Controllers
{
    public class ProductosSearchController : ApiController
    {
        private Entities db = new Entities();
        /*
        private enum Params { 
            Description,
            Categoria,
            Zona,
            PrecioMin,
            PrecioMax,
            Store
        }*/

        // GET api/ProductosSeach
        public IEnumerable<ProductSearch_Result> GetPRODUCTOS()
        {

            var qs = new Mercadosfera.Core.QueryString();
            //var result = new List<ProductSearch_Result>();

            double pMin=0;
            double pMax = 0;

            double.TryParse(qs.Get("pmi"), out pMin);
            double.TryParse(qs.Get("pma"), out pMax);

            var result = db.ProductSearch(qs.Get("d"), qs.Get("c"), qs.Get("z"), pMin, pMax, qs.Get("s"));
 
            return result;


            //return productos.AsEnumerable();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}