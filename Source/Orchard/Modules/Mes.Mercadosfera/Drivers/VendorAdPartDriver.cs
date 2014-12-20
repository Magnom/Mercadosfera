using Mes.Mercadosfera.Models;
using Orchard.ContentManagement.Drivers;

namespace Mes.Mercadosfera.Drivers
{
    public class VendorAdPartDriver : ContentPartDriver<VendorAdPart>
    {
        protected override string Prefix
        {
            get { return "VendorAdd"; }
        }


        protected override DriverResult Display(VendorAdPart part, string displayType, dynamic shapeHelper)
        {

            return ContentShape("Parts_VendorAdd",
                             () => shapeHelper.Parts_VendorAd(
                           Datos: ""));
        }
    }
}