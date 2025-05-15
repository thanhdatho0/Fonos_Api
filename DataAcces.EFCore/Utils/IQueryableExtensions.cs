using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore.Utils
{
    public static class IQueryableExtensions
    {
        public static async Task<PageResult<T>> ToPagedResultAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            var count = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PageResult<T>
            {
                Items = items,
                TotalCount = count,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }
    }
}
