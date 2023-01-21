using Kuari.JwtApplication.Back.Core.Application.DTOs;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands
{
    public class UpdateProductCommandRequest : IRequest<ProductUpdateDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public UpdateProductCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
