using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.BookAuthorDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class BookAuthorMappers
    {
        public static BookAuthorDto ToBookAuthorDto(this BookAuthor bookAuthor)
        {
            return new BookAuthorDto
            {
                Book = bookAuthor.Book?.ToBookDto(),
                Author = bookAuthor.Author?.ToAuthorDto(),
            };
        }

        public static BookAuthor ToBookAuthorFromCreateDto(this BookAuthorCreateDto bookAuthorCreateDto)
        {
            return new BookAuthor
            {
                BookId = bookAuthorCreateDto.BookId,
                AuthorId = bookAuthorCreateDto.AuthorId,
            };
        }
    }
}
