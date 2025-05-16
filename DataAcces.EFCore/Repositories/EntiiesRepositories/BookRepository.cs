using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.EFCore.Dbcontext;
using DataAcces.EFCore.Mappers;
using Domain.DTOs.BookDtos;
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

        public async Task<IEnumerable<Book>> GetAll(PaginationParams? pagination)
        {
            var query = _context.Books.AsQueryable();

            if (pagination != null && pagination.PageNumber > 0 && pagination.PageSize > 0)
            {
                query = query
                    .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                    .Take(pagination.PageSize);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Book?>> GetNewBook()
        {
            return await _context.Books
                .OrderByDescending(a => a.Audiobook!.ReleaseDate)
                .Take(10)
                .ToListAsync();
        }

        public Task<IEnumerable<BookDetailDto?>> GetTopBook()
        {
            throw new NotImplementedException();
        }
    }
}
