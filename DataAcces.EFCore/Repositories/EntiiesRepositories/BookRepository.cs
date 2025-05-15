using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.EFCore.Dbcontext;
using Domain.Entities;
using Domain.Interfaces.IEntitiesRepositories;
using Domain.Pagination;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore.Repositories.EntiiesRepositories
{
    public class BookRepository(ApplicationDbContext context)
        : GenericRepository<Book>(context), IBookRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<int> CountAsync()
        {
            return await _context.Books.CountAsync();
        }

        public async Task<IEnumerable<Book>> GetAll(PaginationParams pagination)
        {

            return await _context.Books
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();
        }
    }
}
