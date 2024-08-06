using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Talakado.Domain.Attributes;

namespace Talakado.Domain.Catalogs
{
    [Auditable]
    public class CatalogItemFavorite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public CatalogItem CatalogItem { get; set; }
        public int CatalogItemId { get; set; }
    }
}
