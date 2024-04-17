using AutoMapper;
using Common;
using Talakado.Application.Contexts;
using Talakado.Application.Dtos;
using Talakado.Domain.Catalogs;

namespace Talakado.Application.Catalogs.CatalogTypes
{
    public class CatalogTypeService : ICatalogTypeService
    {
        private readonly IDataBaseContext _context;
        private readonly IMapper mapper;

        public CatalogTypeService(IDataBaseContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
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
            return new BaseDto<CatalogTypeDto>(true,null,result);
            //return new BaseDto<CatalogTypeDto>(true, "عملیات با موفقیت انجام شد", result); 
        }

        public PaginatedItemDto<CatalogTypeListDto> GetList(int? parentId, int page, int pageSize)
        {
            int totalCount = 0;
            var model = _context.CatalogTypes.Where(p=>p.ParentCatalogTypeId == parentId).PagedResult(page, pageSize, out totalCount);
            var result = mapper.ProjectTo<CatalogTypeListDto>(model).ToList();
            return new PaginatedItemDto<CatalogTypeListDto>(page,pageSize,totalCount,result);
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
