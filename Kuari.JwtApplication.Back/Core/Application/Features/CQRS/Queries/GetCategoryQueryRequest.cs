using Kuari.JwtApplication.Back.Core.Application.DTOs;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryListDto?>
    {
        public int Id { get; set; }

        public GetCategoryQueryRequest(int ıd)
        {
            this.Id = ıd;
        }
    }
}
