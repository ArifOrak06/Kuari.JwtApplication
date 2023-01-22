using AutoMapper;
using Kuari.JwtApplication.Back.Core.Application.DTOs;
using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Queries;
using Kuari.JwtApplication.Back.Core.Application.İnterfaces;
using Kuari.JwtApplication.Back.Core.Domain;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Handlers
{
    public class GetCategoryQueryRequestHandler : IRequestHandler<GetCategoryQueryRequest, CategoryListDto?>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public GetCategoryQueryRequestHandler(IMapper mapper, IRepository<Category> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<CategoryListDto?> Handle(GetCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByFilterAsync(x => x.Id == request.Id);
            return _mapper.Map<CategoryListDto>(data);
        }
    }
}
