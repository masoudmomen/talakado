namespace Talakado.Application.Catalogs.CatalogTypes
{
    public class CatalogTypeListDto
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int SubTypeCount { get; set; }
        public string? ImageAddress { get; set; }
    }
}
