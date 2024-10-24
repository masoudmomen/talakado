﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talakado.Application.Catalogs.CatalogTypes;

namespace Talakado.Application.ContentManager
{
    public class HomePageDto
    {
        public string AdvertisePhrase { get; set; }
        public bool IsShowAdvertisePhrase { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsShowPhoneNumber { get; set; }
        public SliderContent? Slide1 { get; set; }
        public SliderContent? Slide2 { get; set; }
        public SliderContent? Slide3 { get; set; }
        public string? BannerImage { get; set; }
        public List<CatalogTypeForHomePageDto> CatalogTypes { get; set; }
    }

    public class SliderContent
    {
        public string? ImageAddress { get; set; }
        public string? SlideText { get; set; }
    }
    public class CatalogTypeForHomePageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? ImageAddress { get; set; }
        public int ItemCount { get; set; }
    }
}
