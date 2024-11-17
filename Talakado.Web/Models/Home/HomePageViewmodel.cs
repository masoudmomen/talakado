using Talakado.Application.ContentManager;

namespace Talakado.Web.Models.Home
{
    public class HomePageViewmodel
    {
        public SliderContent? Slide1 { get; set; }
        public SliderContent? Slide2 { get; set; }
        public SliderContent? Slide3 { get; set; }
        public string? BannerImage { get; set; }
        public List<CatalogTypeForHomePageDto> CatalogTypes { get; set; }
        public BannerContent? BannerTR { get; set; }
        public BannerContent? BannerTL { get; set; }
        public BannerContent? BannerBR { get; set; }
        public BannerContent? BannerBL { get; set; }
        public BannerContent? BannerMid { get; set; }
    }
}
