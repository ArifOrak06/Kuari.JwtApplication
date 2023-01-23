using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands;
using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kuari.JwtApplication.Back.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserCommandRequest request)
        {
            await _mediator.Send(request);
            return Created("",request);
        }
        [HttpPost]
        public async Task<IActionResult> Login(CheckUserQueryRequest request)
        {
            var dto = await  _mediator.Send(request); // handle classında kullanıcı dbde varsa IsExist true olarak setlenecektir, burada durum kontrolü yapılması gerekiyor.
            if (dto.IsExist)
            {
                return Created("", "Token oluşturuldu");

            }
            else
            {
                return BadRequest("Kullanıcı adı veya parola hatalı");
            }
        }
    }
}
