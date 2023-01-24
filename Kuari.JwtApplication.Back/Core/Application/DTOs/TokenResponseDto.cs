namespace Kuari.JwtApplication.Back.Core.Application.DTOs
{
    public class TokenResponseDto
    {
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }

        public TokenResponseDto(string? token, DateTime expireDate)
        {
            this.Token = token;
            this.ExpireDate = expireDate;
        }
    }
}
