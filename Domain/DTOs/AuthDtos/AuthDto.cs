
namespace Domain.DTOs.AuthDtos
{
    public class AuthDto
    {
        public string Id { get; set; } = string.Empty;
        public TokenDto? Tokens { get; set; }
    }
}
