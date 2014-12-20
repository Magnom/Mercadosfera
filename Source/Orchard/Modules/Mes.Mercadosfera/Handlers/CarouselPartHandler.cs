using Orchard.ContentManagement.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mes.Mercadosfera.Models;
using Orchard.Data;

namespace Mes.Mercadosfera.Handlers
{
     public class CarouselPartHandler : ContentHandler
     {
         public CarouselPartHandler(IRepository<CarouselPartRecord> repository)
         {
             Filters.Add(StorageFilter.For(repository));
         }
     }
}
