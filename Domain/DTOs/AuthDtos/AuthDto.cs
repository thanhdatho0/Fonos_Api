
namespace Domain.DTOs.AuthDtos
{
    public class AuthDto
    {
        public string Id { get; set; } = null!;
        public TokenDto? Tokens { get; set; }
    }
}
