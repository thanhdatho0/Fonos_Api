using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.DTOs.PlaylistItemDtos
{
    public class PlaylistItemDto
    {
        public Guid PlaylistItemId { get; set; }
        public DateTime AddedDate { get; set; }
        public string DisplayOrder { get; set; } = null!;
        public Guid UserPlaylistId { get; set; }
        public Guid BookId { get; set; }
    }
}
