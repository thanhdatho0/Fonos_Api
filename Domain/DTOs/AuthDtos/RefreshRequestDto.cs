﻿

namespace Domain.DTOs.AuthDtos
{
    public class RefreshRequestDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
