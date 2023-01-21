namespace Kuari.JwtApplication.Back.Core.Application.DTOs
{
    public class ProductUpdateDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

      
    }
}
