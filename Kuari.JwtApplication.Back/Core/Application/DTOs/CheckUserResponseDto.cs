namespace Kuari.JwtApplication.Back.Core.Application.DTOs
{
    public class CheckUserResponseDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public bool IsExist { get; set; } = true;
    }
}
