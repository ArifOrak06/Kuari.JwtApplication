using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands;
using Kuari.JwtApplication.Back.Core.Application.İnterfaces;
using Kuari.JwtApplication.Back.Core.Domain;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandRequestHandler : IRequestHandler<UpdateCategoryCommandRequest>
    {
        private readonly IRepository<Category> _repository;

        public UpdateCategoryCommandRequestHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            if(data != null)
            {
                data.Definition = request.Definition;
                await _repository.UpdateAsync(data);
                return Unit.Value;

            }
            return Unit.Value;
        }
    }
}
