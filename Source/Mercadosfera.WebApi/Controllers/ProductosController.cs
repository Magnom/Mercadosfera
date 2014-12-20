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

namespace Mercadosfera.WebApi.Controllers
{
    public class ProductosController : ApiController
    {
        private Entities db = new Entities();

        // GET api/Productos
        public IEnumerable<PRODUCTOS> GetPRODUCTOS()
        {
            //var productos = db.PRODUCTOS.Include(p => p.CERTIFICADOS).Include(p => p.FORMATOS).Include(p => p.TIPOPRODUCTO).Include(p => p.T);
            //return productos.AsEnumerable();
            return null;
        }

        // GET api/Productos/5
        public PRODUCTOS GetPRODUCTOS(int id)
        {
            PRODUCTOS productos = db.PRODUCTOS.Find(id);
            if (productos == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return productos;
        }

        // PUT api/Productos/5
        public HttpResponseMessage PutPRODUCTOS(int id, PRODUCTOS productos)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != productos.ID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(productos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Productos
        public HttpResponseMessage PostPRODUCTOS(PRODUCTOS productos)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCTOS.Add(productos);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, productos);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = productos.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Productos/5
        public HttpResponseMessage DeletePRODUCTOS(int id)
        {
            PRODUCTOS productos = db.PRODUCTOS.Find(id);
            if (productos == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.PRODUCTOS.Remove(productos);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, productos);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}