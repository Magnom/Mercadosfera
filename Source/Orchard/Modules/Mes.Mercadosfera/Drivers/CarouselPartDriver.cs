using Mes.Mercadosfera.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

 

namespace Mes.Mercadosfera.Drivers
{
    public class CarouselPartDriver : ContentPartDriver<CarouselPart>
    {
        protected override string Prefix
        {
            get { return "Carousel"; }
        }

        protected override DriverResult Editor(CarouselPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_CarouselPart_Edit", () => shapeHelper
                .EditorTemplate(TemplateName: "Parts/Carousel", Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(CarouselPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            //Evaluo si es insert updata

            //crido al webservice o framework

            //Actualitzo el del orchard

            return Editor(part, shapeHelper);
        }

        protected override DriverResult Display(CarouselPart part, string displayType, dynamic shapeHelper)
        {
            //return ContentShape("Parts_CarouselPart", () => shapeHelper(TemplateName: "Parts/Carousel", Model: part, Prefix: Prefix));


            return ContentShape("Parts_CarouselPart",
                             () => shapeHelper.Parts_Carousel(
                           Datos: part.Datos));
        }
    }
}
