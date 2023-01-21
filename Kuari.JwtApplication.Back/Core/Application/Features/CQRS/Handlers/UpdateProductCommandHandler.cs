using AutoMapper;
using Kuari.JwtApplication.Back.Core.Application.DTOs;
using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands;
using Kuari.JwtApplication.Back.Core.Application.İnterfaces;
using Kuari.JwtApplication.Back.Core.Domain;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, ProductUpdateDto>
    {
        private readonly IRepository<Product> _repository;
        private readonly IMapper _mapper;

        public UpdateProductCommandHandler(IRepository<Product> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProductUpdateDto> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedEntity = await _repository.GetByIdAsync(request.Id);
            if (updatedEntity != null)
            {

                updatedEntity.Stock = request.Stock;
                updatedEntity.Name = request.Name;
                updatedEntity.CategoryId = request.CategoryId;
                updatedEntity.Price = request.Price;
                await _repository.UpdateAsync(updatedEntity);
                return _mapper.Map<ProductUpdateDto>(updatedEntity);

            }
            return new ProductUpdateDto();
        }
    }
}
