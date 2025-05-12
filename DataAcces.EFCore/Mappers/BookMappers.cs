using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.BookDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book book)
        {
            return new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                PublicationYear = book.PublicationYear,
                Description = book.Description,
                CoverImageUrl = book.CoverImageUrl,
                Language = book.Language,
                Price = book.Price,
            };
        }

        public static Book ToBookFromCreateDto(this BookCreateDto bookCreateDto)
        {
            return new Book
            {
                Title = bookCreateDto.Title,
                ISBN = bookCreateDto.ISBN,
                PublisherId = bookCreateDto.PublisherId,
                PublicationYear = bookCreateDto.PublicationYear,
                Description = bookCreateDto.Description,
                CoverImageUrl = bookCreateDto.CoverImageUrl,
                Language = bookCreateDto.Language,
                Price = bookCreateDto.Price,
                CreatedDate = DateTime.UtcNow,
            };
        }

        public static BookDetailDto ToBookDetailDto(this Book book)
        {
            return new BookDetailDto
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                PublicationYear = book.PublicationYear,
                Description = book.Description,
                CoverImageUrl = book.CoverImageUrl,
                Language = book.Language,
                Price = book.Price,
                CreatedDate = book.CreatedDate,
                UpdatedDate = book.UpdatedDate,
                Audiobook = book.Audiobook?.ToAudiobookDto(),
                Publisher = book.Publisher?.ToPublisherDto(),
            };
        }

        public static void ToBookFromUpdateDto(this Book book, BookUpdateDto bookUpdateDto)
        {
            book.Title = bookUpdateDto.Title;
            book.ISBN = bookUpdateDto.ISBN;
            book.PublisherId = bookUpdateDto.PublisherId;
            book.PublicationYear = bookUpdateDto.PublicationYear;
            book.Description = bookUpdateDto.Description;
            book.CoverImageUrl = bookUpdateDto.CoverImageUrl;
            book.PageCount = bookUpdateDto.PageCount;
            book.Language = bookUpdateDto.Language;
            book.Price = bookUpdateDto.Price;
            book.IsActive = bookUpdateDto.IsActive;
            book.UpdatedDate = DateTime.UtcNow;
        }
    }
}
