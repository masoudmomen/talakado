﻿namespace Talakado.Application.Catalogs.GetMenuItems
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<MenuItemDto> SubMenu { get; set; }
    }
}
