﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.BookAuthorDtos
{
    public class BookAuthorCreateDto
    {
        public Guid BookId { get; set; }
        public Guid AuthorId { get; set; }
    }
}
