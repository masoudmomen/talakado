using AutoMapper;
using Common;
using Talakado.Application.Contexts;
using Talakado.Application.Dtos;
using Talakado.Application.UriComposer;
using Talakado.Domain.Catalogs;

namespace Talakado.Application.Catalogs.CatalogTypes
{
    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper mapper;
        private readonly IUriComposerService uriComposerService;

        public CatalogTypeService(IDataBaseContext context, IMapper mapper, IUriComposerService uriComposerService)
        {
            _context = context;
            this.mapper = mapper;
            this.uriComposerService = uriComposerService;
        }
        public BaseDto<CatalogTypeDto> Add(CatalogTypeDto catalogType)
        {
            var model = mapper.Map<CatalogType>(catalogType);
            _context.CatalogTypes.Add(model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(
                true, 
                new List<string> { $"تایپ {model.Type}با موفقیت در سیستم ثبت شد" },
                mapper.Map<CatalogTypeDto>(model)
                );
        }

        public BaseDto<CatalogTypeDto> Edit(CatalogTypeDto catalogType)
        {
            var model = _context.CatalogTypes.SingleOrDefault(p=>p.Id==catalogType.Id); 
            mapper.Map(catalogType,model);
            _context.SaveChanges();
            return new BaseDto<CatalogTypeDto>(
                true,
                new List<string> { $"تایپ {model.Type} با موفقیت ویرایش شد" },
                mapper.Map<CatalogTypeDto>(model)
                );
        }

        public BaseDto<CatalogTypeDto> FindById(int Id)
        {
            var data = _context.CatalogTypes.Find(Id);
            var result = mapper.Map<CatalogTypeDto>(data);
            result.ImageAddress = uriComposerService.ComposeImageUri(result.ImageAddress);
            return new BaseDto<CatalogTypeDto>(true,null,result);
            //return new BaseDto<CatalogTypeDto>(true, "عملیات با موفقیت انجام شد", result); 
        }

        public PaginatedItemDto<CatalogTypeListDto> GetList(int? parentId, int pageIndex, int pageSize)
        {
            int totalCount = 0;
            var model = _context.CatalogTypes.Where(p=>p.ParentCatalogTypeId == parentId).PagedResult(pageIndex, pageSize, out totalCount);
            var result = mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
            foreach (var item in result)
            {
                if (!string.IsNullOrEmpty(item.ImageAddress))
                {
                    item.ImageAddress = uriComposerService.ComposeImageUri(item.ImageAddress);
                }
            }
            return new PaginatedItemDto<CatalogTypeListDto>(pageIndex, pageSize,totalCount,result);
        }

        public BaseDto Remove(int Id)
        {
            var catalogType = _context.CatalogTypes.Find(Id);
            _context.CatalogTypes.Remove(catalogType);
            _context.SaveChanges();
            return new BaseDto(
                true,
                new List<string> { "آیتم با موفقیت حذف شد" });
        }
    }
}
