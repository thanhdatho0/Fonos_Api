using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.UserPlaylistDtos
{
    public class UserPlaylistCreateDto
    {
        public string AppUserId { get; set; } = null!;
        public string PlaylistName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public bool IsPublic { get; set; }
    }
}
