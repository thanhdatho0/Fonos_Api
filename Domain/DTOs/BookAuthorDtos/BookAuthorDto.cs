using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.AuthDtos;
using Domain.DTOs.AuthorDtos;
using Domain.DTOs.BookDtos;

namespace Domain.DTOs.BookAuthorDtos
{
    public class BookAuthorDto
    {
        public BookDto? Book { get; set; }
        public AuthorDto? Author { get; set; }
    }
}
