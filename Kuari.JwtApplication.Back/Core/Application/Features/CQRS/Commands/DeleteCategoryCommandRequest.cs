using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands
{
    public class DeleteCategoryCommandRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteCategoryCommandRequest(int id)
        {
            this.Id = id;
        }
    }
}
