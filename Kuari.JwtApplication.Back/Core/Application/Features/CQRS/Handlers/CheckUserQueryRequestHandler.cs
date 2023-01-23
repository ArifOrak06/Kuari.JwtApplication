using Kuari.JwtApplication.Back.Core.Application.DTOs;
using Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Queries;
using Kuari.JwtApplication.Back.Core.Application.İnterfaces;
using Kuari.JwtApplication.Back.Core.Domain;
using MediatR;

namespace Kuari.JwtApplication.Back.Core.Application.Features.CQRS.Handlers
{
    public class CheckUserQueryRequestHandler : IRequestHandler<CheckUserQueryRequest, CheckUserResponseDto> 
    {
        private readonly IRepository<AppUser> _userRepository;
        private readonly IRepository<AppRole> _roleRepository;

        public CheckUserQueryRequestHandler(IRepository<AppUser> userRepository, IRepository<AppRole> roleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<CheckUserResponseDto> Handle(CheckUserQueryRequest request, CancellationToken cancellationToken)
        {

            // bu method login kontrolü için yazıldı, clienttan gelen data ile db deki data eşleşirse token üretilip client'a dönülecek.Token ile ilgili method ayrı olarak ele alındı.
            var dto = new CheckUserResponseDto();

            var user = await _userRepository.GetByFilterAsync(x=> x.Username == request.Username & x.Password == request.Password);

            if (user == null)
            {
                dto.IsExist = false;

            }
            else
            {
                dto.Username =  user.Username;
                dto.Id = user.Id;
                var role = await _roleRepository.GetByFilterAsync(x => x.Id == user.AppRoleId);
                dto.Role = role?.Definition;

            }
            return dto;
        }
    }
}
