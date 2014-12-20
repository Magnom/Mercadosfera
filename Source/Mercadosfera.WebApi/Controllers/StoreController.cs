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
    public class StoreController : ApiController
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
        public IEnumerable<GetStore_Result> GetStore()
        {

            var qs = new Mercadosfera.Core.QueryString();
            //var result = new List<ProductSearch_Result>();

            int pIdStore = 0;

            Int32.TryParse(qs.Get("t"), out pIdStore);

            var result = db.GetStore(pIdStore);

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