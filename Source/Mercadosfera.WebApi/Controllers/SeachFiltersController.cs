using Mercadosfera.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mercadosfera.WebApi.Controllers
{
    public class SeachFiltersController : ApiController
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


        private IEnumerable<SelecValue> GetCategories(string zone, string store, double min, double max)
        {
            return db.CategorySearch(zone, store, min, max);
        }

        private IEnumerable<SelecValue> GetZones(string category, string store, double min, double max)
        {
            return db.ZoneSearch(category, store, min, max);
        }

        private IEnumerable<SelecValue> GetStores(string category, string zone, double min, double max)
        {
            return db.StoreSearch(category, zone, min, max);
        }

        public IEnumerable<SelecValue> GetPRODUCTOS()
        {

            var qs = new Mercadosfera.Core.QueryString();

            double pMin = 0;
            double pMax = 0;

            double.TryParse(qs.Get("pmi"), out pMin);
            double.TryParse(qs.Get("pma"), out pMax);

            switch (qs.Get("type")) {
                case "c": return GetCategories(qs.Get("z"), qs.Get("s"), pMin, pMax); break;
                case "z": return GetZones(qs.Get("c"), qs.Get("s"), pMin, pMax); break;
                case "s": return GetStores(qs.Get("c"), qs.Get("z"), pMin, pMax); break;
            }

            return new List<SelecValue>();

        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
