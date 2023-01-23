using Kuari.JwtApplication.Back.Core.Application.Enums;
using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Commands;
using Kuari.JwtApplication.Back.Core.Application.İnterfaces;
using Kuari.JwtApplication.Back.Core.Domain;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Handlers
{
    public class RegisterUserCommandRequestHandler : IRequestHandler<RegisterUserCommandRequest>
    {
        private readonly IRepository<AppUser> _repository;

        public RegisterUserCommandRequestHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new AppUser()
            {
                Username = request.Username,
                Password = request.Password,
                AppRoleId = (int)RoleType.Member
            });
            return Unit.Value;
        }
    }
}
