using Kuari.JwtApplication.Back.Core.Application.DTOs;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

    }
}
