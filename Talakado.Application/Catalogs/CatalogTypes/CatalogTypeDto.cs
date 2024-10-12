namespace Talakado.Application.Catalogs.CatalogTypes
{
    public class CatalogTypeDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int? ParentCatalogTypeId { get; set; }
        public string? ImageAddress { get; set; }
    }
}
