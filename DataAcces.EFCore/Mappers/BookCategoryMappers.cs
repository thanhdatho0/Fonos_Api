using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.BookCategoryDtos;
using Domain.Entities;

namespace DataAcces.EFCore.Mappers
{
    public static class BookCategoryMappers
    {
        public static BookCategoryDto ToBookCategoryDto(this BookCategory bookCategory)
        {
            return new BookCategoryDto
            {
                Category = bookCategory.Category?.ToCategoryDto(),
                Book = bookCategory.Book?.ToBookDto(),
            };
        }

        public static BookCategory ToBookCategoryFromCreateDto(this BookCategoryCreateDto bookCategoryCreateDto)
        {
            return new BookCategory
            {
                BookId = bookCategoryCreateDto.BookId,
                CategoryId = bookCategoryCreateDto.CategoryId,
            };
        }
    }
}
