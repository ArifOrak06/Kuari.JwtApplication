using Kuari.JwtApplication.Back.Core.Application.DTOs;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Queries
{
    public class GetAllProductsQueryRequest : IRequest<List<ProductListDto>>
    {

    }
}
