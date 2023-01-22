using Kuari.JwtApplication.Back.Core.Application.DTOs;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest<CategoryCreateDto?>
    {
        public string? Definition { get; set; }

    }
}
