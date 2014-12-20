using Orchard.UI.Resources;

namespace Mes.Mercadosfera
{
    public class ResourceManifest : IResourceManifestProvider
    {
        public void BuildManifests(ResourceManifestBuilder builder)
        {
            var manifest = builder.Add();
            manifest.DefineScript("ContentPicker").SetUrl("ContentPicker.js", "ContentPicker.js").SetDependencies("jQuery");
            manifest.DefineStyle("OwlCarouselTheme").SetUrl("owl.theme.css");
            manifest.DefineStyle("OwlCarousel").SetUrl("owl.carousel.css");
            manifest.DefineStyle("Carousel").SetUrl("carousel.css");
            manifest.DefineStyle("ProductChart").SetUrl("productChart.css");
            manifest.DefineStyle("SearchInput").SetUrl("searchInput.css");
            manifest.DefineStyle("Mes.Search").SetUrl("Mes.Search.css");
            manifest.DefineStyle("Mes.ProductDetail").SetUrl("Mes.ProductDetail.css");
            
        }
    }
}
