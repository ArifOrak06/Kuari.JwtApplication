using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands;
using Kuari.JwtApplication.Back.Core.Application.İnterfaces;
using Kuari.JwtApplication.Back.Core.Domain;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCategoryCommandRequestHandler : IRequestHandler<DeleteCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public DeleteCategoryCommandRequestHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            if(data != null)
            {
                await _repository.DeleteAsync(data);
                return Unit.Value;
            }
            return Unit.Value;
        }
    }
}
