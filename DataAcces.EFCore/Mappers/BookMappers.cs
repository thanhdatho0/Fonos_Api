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
    }
}
