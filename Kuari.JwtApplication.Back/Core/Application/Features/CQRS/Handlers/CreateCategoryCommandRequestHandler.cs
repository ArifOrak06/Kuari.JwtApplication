using AutoMapper;
using Kuari.JwtApplication.Back.Core.Application.DTOs;
using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands;
using Kuari.JwtApplication.Back.Core.Application.İnterfaces;
using Kuari.JwtApplication.Back.Core.Domain;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandRequestHandler : IRequestHandler<CreateCategoryCommandRequest, CategoryCreateDto?>
    {
        private readonly IRepository<Category> _repository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandRequestHandler(IRepository<Category> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CategoryCreateDto?> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var newCategory = new Category()
            {
                Definition = request.Definition
            };
            await _repository.CreateAsync(newCategory);
            return _mapper.Map<CategoryCreateDto>(newCategory);


        }
    }
}
