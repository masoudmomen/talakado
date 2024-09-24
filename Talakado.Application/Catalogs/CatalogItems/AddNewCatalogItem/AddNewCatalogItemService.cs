using AutoMapper;
using Talakado.Application.Contexts;
using Talakado.Application.Dtos;
using Talakado.Domain.Catalogs;

namespace Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
    public class AddNewCatalogItemService : IAddNewCatalogItemService
    {
        private readonly IDataBaseContext context;
        private readonly IMapper mapper;

        public AddNewCatalogItemService(IDataBaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<int> Execute(AddNewCatalogItemDto request)
        {
            if (request == null) return new BaseDto<int>(false, new List<string> { "ایراد در ثبت محصول" }, 0);
            //var catalogItem = mapper.Map<CatalogItem>(request);
            var catalogItem = new CatalogItem();
            catalogItem.AvailableStock = request.AvailableStock;
            catalogItem.AvailableStock = request.AvailableStock;
            catalogItem.ReStockThreshold = request.ReStockThreshold;
            catalogItem.MaxStockThreshold = request.MaxStockThreshold;
            catalogItem.CatalogBrandId = request.CatalogBrandId;
            catalogItem.CatalogTypeId = request.CatalogTypeId;
            catalogItem.Description = (request.Description == null)?"":request.Description;
            catalogItem.SetPrice(request.Price);
            catalogItem.Name = (request.Name == null) ? "" : request.Name;
            catalogItem.Slug = (request.Name == null) ? "" : request.Name;

            context.CatalogItems.Add(catalogItem);
            if(context.SaveChanges() > 0)
            {
                if (request.Images != null && request.Images.Count > 0)
                {
                    foreach (var item in request.Images)
                    {
                        var CatalogItemImages = new CatalogItemImage
                        {
                            CatalogItemId = catalogItem.Id,
                            Src = (item.Src == null) ? "" : item.Src,
                            CatalogItem = catalogItem
                        };
                        context.CatalogItemImage.Add(CatalogItemImages);
                    }
                    
                }
                if (request.Features != null && request.Features.Count > 0)
                {
                    foreach (var item in request.Features)
                    {
                        var CatalogItemFeatures = new CatalogItemFeature
                        {
                            CatalogItem = catalogItem,
                            Group = item.Group,
                            Key = item.Key,
                            Value = item.Value
                        };
                        context.CatalogItemFeature.Add(CatalogItemFeatures);
                    }
                }
                if (context.SaveChanges() > 0)
                {
                    return new BaseDto<int>(true, new List<string> { "محصول با موفقیت ثبت شد" }, catalogItem.Id);
                }
                return new BaseDto<int>(true, new List<string> { "محصول ثبت شد ولی ویژگی ها و عکس ها ثبت نشد، می توانید در ویرایش عکس ها و ویژگی ها را اضافه کنید" }, catalogItem.Id);
            }
            return new BaseDto<int>(false, new List<string> { "ثبت محصول با خطا مواجه شد" }, catalogItem.Id);

        }
    }
}
