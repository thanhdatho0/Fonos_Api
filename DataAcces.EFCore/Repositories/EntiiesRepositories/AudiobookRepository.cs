using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.EFCore.Dbcontext;
using DataAcces.EFCore.Mappers;
using Domain.Entities;
using Domain.Interfaces.IEntitiesRepositories;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.EFCore.Repositories.EntiiesRepositories
{
    public class AudiobookRepository(ApplicationDbContext context)
        : GenericRepository<Audiobook>(context), IAudiobookRepository
    {
        private readonly ApplicationDbContext _context = context;

        //public async Task<IEnumerable<Audiobook?>> GetAudiobooksHaveSameAuthor(Guid auiobookId)
        //{
        //    var book = await _context.Books
        //        .FirstOrDefaultAsync(b => b.Audiobook!.AudiobookId == auiobookId);

        //    var bookAuthor = await _context.BookAuthors
        //        .Where(b => b.BookId == book!.BookId).ToListAsync();

        //    return bookAuthor.Select(b => b.ToBookAuthorDto());
        //}

        //public Task<IEnumerable<Audiobook?>> GetAudiobooksHaveSameCategory(Guid auiobookId)
        //{
        //    return await _context.Ratings
        //        .OrderBy(r => r.RatingValue)
        //        .Take(10)
        //        .Select(r => r.Book)
        //        .Select(r => r!.Audiobook)
        //        .ToListAsync();
        //}

        //public Task<IEnumerable<Audiobook?>> GetAudiobooksHaveSamePublisher(Guid auiobookId)
        //{
        //    return await _context.Ratings
        //        .OrderBy(r => r.RatingValue)
        //        .Take(10)
        //        .Select(r => r.Book)
        //        .Select(r => r!.Audiobook)
        //        .ToListAsync();
        //}

        public async Task<IEnumerable<Audiobook?>> GetNewAudiobook()
        {
            return await _context.Audiobooks
                .OrderByDescending(a => a.ReleaseDate)
                .Take(10)
                .ToListAsync();
        }

        public async Task<IEnumerable<Audiobook?>> GetTopAudiobook()
        {
            return await _context.Ratings
                .OrderByDescending(r => r.RatingValue)
                .Take(10)
                .Select(r => r.Book)
                .Select(r => r!.Audiobook)
                .ToListAsync();
        }
    }
}
