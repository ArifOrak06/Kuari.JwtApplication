using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands;
using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kuari.JwtApplication.Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result = await _mediator.Send(new GetCategoriesQueryRequest());
            return result == null ? NotFound() : Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _mediator.Send(new GetCategoryQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddedCategory(CreateCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommandRequest request)
        {
            var result = await _mediator.Send(request);
            return NoContent();
        }
    
    
    }
}
