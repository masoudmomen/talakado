﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talakado.Application.Dtos
{
    public class PaginatedItemDto<TEntity> where TEntity : class
    {
        public PaginatedItemDto(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Data = data;
            TotalPages = (int)Math.Ceiling((decimal)count / (decimal)PageSize);
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<TEntity> Data { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPerviousPage 
        {
            get
            {
                return (PageIndex > 1);
            }        
        }
        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }
    }
}
