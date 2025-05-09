using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.BookCategoryDtos
{
    public class BookCategoryCreateDto
    {
        public Guid BookId { get; set; }
        public Guid CategoryId { get; set; }
    }
}
