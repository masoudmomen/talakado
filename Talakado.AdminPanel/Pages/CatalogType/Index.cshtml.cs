using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Talakado.Application.Catalogs.CatalogTypes;
using Talakado.Application.Dtos;

namespace Talakado.AdminPanel.Pages.CatalogType
{
    public class IndexModel : PageModel
    {
        private readonly ICatalogTypeService catalogTypeService;

        public IndexModel(ICatalogTypeService catalogTypeService)
        {
            this.catalogTypeService = catalogTypeService;
        }
        public PaginatedItemDto<CatalogTypeListDto> CatalogType { get; set; }
        public void OnGet(int? parentId, int page=1, int pageSize=100)
        {
            CatalogType = catalogTypeService.GetList(parentId, page, pageSize);
        }
    }
}
