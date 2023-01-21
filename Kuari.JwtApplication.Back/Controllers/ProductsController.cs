using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands;
using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kuari.JwtApplication.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductsQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var result = await _mediator.Send(new GetProductQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteProductCommandRequest(id));
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return result == null ? NotFound() : Created(string.Empty,result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id) 
        { 
            var result = await _mediator.Send(new UpdateProductCommandRequest(id));
            return result == null ? NotFound() : Ok(result);
        }
    }
}
