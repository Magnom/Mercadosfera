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
    public class VendedoresController : ApiController
    {
        private Entities db = new Entities();

        // GET api/Vendedores
        public IEnumerable<VENDEDORES> GetVENDEDORES()
        {
            return db.VENDEDORES.AsEnumerable();
        }

        // GET api/Vendedores/5
        public VENDEDORES GetVENDEDORES(string id)
        {
            VENDEDORES vendedores = db.VENDEDORES.Find(id);
            if (vendedores == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return vendedores;
        }

        // PUT api/Vendedores/5
        public HttpResponseMessage PutVENDEDORES(string id, VENDEDORES vendedores)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != vendedores.OrchardId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(vendedores).State = EntityState.Modified;

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

        // POST api/Vendedores
        public HttpResponseMessage PostVENDEDORES(VENDEDORES vendedores)
        {
            if (ModelState.IsValid)
            {
                db.VENDEDORES.Add(vendedores);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, vendedores);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = vendedores.OrchardId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Vendedores/5
        public HttpResponseMessage DeleteVENDEDORES(string id)
        {
            VENDEDORES vendedores = db.VENDEDORES.Find(id);
            if (vendedores == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.VENDEDORES.Remove(vendedores);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, vendedores);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}