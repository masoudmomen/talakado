using Talakado.Domain.Attributes;

namespace Talakado.Domain.Catalogs
{
    [Auditable]
    public class CatalogType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
        public CatalogType ParentCatalogType { get; set; }
        public ICollection<CatalogType> SubType { get; set; }
        public string? ImageAddress { get; set; }
    }
}
