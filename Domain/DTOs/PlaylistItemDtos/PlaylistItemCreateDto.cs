using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTOs.PlaylistItemDtos
{
    public class PlaylistItemCreateDto
    {
        public Guid UserPlaylistId { get; set; }
        public Guid BookId { get; set; }
        public string DisplayOrder { get; set; } = null!;
    }
}
