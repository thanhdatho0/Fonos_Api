

namespace Domain.DTOs.AuthDtos
{
    public class RefreshRequestDto
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;
    }
}
