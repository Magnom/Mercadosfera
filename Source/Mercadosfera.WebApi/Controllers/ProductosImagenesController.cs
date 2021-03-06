﻿using System;
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
    public class ProductosImagenesController : ApiController
    {
        private Entities db = new Entities();
      
        // GET api/ProductosDetalle
        public IEnumerable<GetProductosImagenes_Result> GetProductosImagenes()
        {

            var qs = new Mercadosfera.Core.QueryString();
            
            int pIdProducto = 0;
            

            Int32.TryParse(qs.Get("p"), out pIdProducto);


            var result = db.GetProductosImagenes(pIdProducto);

            return result;
      
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}