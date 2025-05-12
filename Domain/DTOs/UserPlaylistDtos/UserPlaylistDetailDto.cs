using System;
using System.Collections.Generic;

using Domain.DTOs.AppUserDtos;

namespace Domain.DTOs.UserPlaylistDtos
{
    public class UserPlaylistDetailDto
    {
        public Guid UserPlaylistId { get; set; }
        public string AppUserId { get; set; } = null!;
        public string PlaylistName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsPublic { get; set; }
        public AppUserDto? AppUser { get; set; }
    }
}
