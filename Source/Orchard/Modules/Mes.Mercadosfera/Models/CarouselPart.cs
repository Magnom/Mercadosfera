using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

using System;

namespace Mes.Mercadosfera.Models
{
    public class CarouselPart : ContentPart<CarouselPartRecord>
    {
        public string UrlImage
        {
            get { return Record.UrlImage; }
            set { Record.UrlImage = value; }
        }

        public string Descripcion
        {
            get { return Record.Descripcion; }
            set { Record.Descripcion = value; }
        }

        public string Texto
        {
            get { return Record.Texto; }
            set { Record.Texto = value; }
        }

        public int IdCarousel
        {
            get {                
                return Record.IdCarousel;
            }
            set { Record.IdCarousel = value; }
        }

        public string Datos
        {
            get
            {
                return Record.Datos;
            }
            set { Record.Datos = value; }
        }  
    }


    public class CarouselPartRecord : ContentPartRecord
    {
        public virtual string UrlImage { get; set; }
        public virtual string Texto { get; set; }
        public virtual int IdCarousel { get; set; }
        public virtual string Descripcion{ get; set; }
        public virtual string Datos { get; set; }        
    }

}