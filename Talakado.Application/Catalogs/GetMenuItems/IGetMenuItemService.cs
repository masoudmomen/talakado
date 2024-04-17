using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Application.Catalogs.GetMenuItems
{
    public interface IGetMenuItemService
    {
        List<MenuItemDto> Execute();
    }
}
