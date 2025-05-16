using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.EFCore.Dbcontext;
using Domain.Entities;
using Domain.Interfaces.IEntitiesRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore.Repositories.EntiiesRepositories
{
    public class RatingRepository(ApplicationDbContext context)
        : GenericRepository<Rating>(context), IRatingRepository
    {
        private readonly ApplicationDbContext _context = context;
        public async Task<double> CalcAvgRatings(Guid bookId)
        {
            return await _context.Ratings
                .Where(r => r.BookId == bookId)
                .Select(r => (double?)r.RatingValue)
                .AverageAsync() ?? 0.0;

        }

        public async Task<int> NumberOfReviws(Guid bookId)
        {
            return await _context.Ratings
                .Where(r => r.BookId == bookId)
                .CountAsync();
        }
    }
}
