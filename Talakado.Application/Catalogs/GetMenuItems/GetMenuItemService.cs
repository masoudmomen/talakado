using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Talakado.Application.Contexts;

namespace Talakado.Application.Catalogs.GetMenuItems
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public GetMenuItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<MenuItemDto> Execute()
        {
            //var catalogType = context.CatalogTypes.Include(p => p.ParentCatalogTypeId).ToList();
            var catalogType = context.CatalogTypes.ToList();
            var data = mapper.Map<List<MenuItemDto>>(catalogType);
            return data;
        }
    }
}
