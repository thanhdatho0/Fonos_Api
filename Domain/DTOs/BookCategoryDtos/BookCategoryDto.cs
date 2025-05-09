using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.BookDtos;
using Domain.DTOs.CategoryDtos;

namespace Domain.DTOs.BookCategoryDtos
{
    public class BookCategoryDto
    {
        public CategoryDto? Category { get; set; }
        public BookDto? Book { get; set; }
    }
}
