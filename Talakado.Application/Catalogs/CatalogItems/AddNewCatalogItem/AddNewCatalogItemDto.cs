using FluentValidation;
using SharpCompress.Archives;

namespace Talakado.Application.Catalogs.CatalogItems.AddNewCatalogItem
{
    public class AddNewCatalogItemDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int CatalogTypeId { get; set; }
        public int CatalogBrandId { get; set; }
        public int AvailableStock { get; set; }
        public int ReStockThreshold { get; set; }
        public int MaxStockThreshold { get; set; }
        public List<AddNewCatalogItemFeature_Dto>? Features { get; set; }
        public List<AddNewCatalogItemImage_Dto>? Images { get; set; }
    }

    public class AddNewCatalogItemDtoValidator: AbstractValidator<AddNewCatalogItemDto>
    {
        public AddNewCatalogItemDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().WithMessage("نام کاتالوگ اجباری است");
            RuleFor(p => p.Name).Length(2, 100);
            RuleFor(p => p.Description).NotNull().WithMessage("توضیحات نمی تواند خالی باشد");
            RuleFor(p => p.AvailableStock).InclusiveBetween(0, int.MaxValue);
            RuleFor(p => p.Price).InclusiveBetween(0, int.MaxValue);
            RuleFor(p => p.Price).NotNull();
        }
    }
}
