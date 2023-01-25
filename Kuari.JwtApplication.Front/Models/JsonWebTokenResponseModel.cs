namespace Kuari.JwtApplication.Front.Models
{
    public class JsonWebTokenResponseModel
    {
        public string? Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
