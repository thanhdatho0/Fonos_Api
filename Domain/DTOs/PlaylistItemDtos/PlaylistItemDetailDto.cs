using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.BookDtos;
using Domain.DTOs.UserPlaylistDtos;
using Domain.Entities;

namespace Domain.DTOs.PlaylistItemDtos
{
    public class PlaylistItemDetailDto
    {
        public Guid PlaylistItemId { get; set; }
        public DateTime AddedDate { get; set; }
        public string DisplayOrder { get; set; } = null!;
        public Guid UserPlaylistId { get; set; }
        public UserPlaylistDto? UserPlaylist { get; set; }
        public Guid BookId { get; set; }
        public BookDto? Book { get; set; }
    }
}
