using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Core;
using TestTask.Application.Interfaces;
using TestTask.Domain.Models.User.Login;

namespace TestTask.Application.CQRS.User.Commads.Login
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ApiResult<LoginResponse>>
    {
        private readonly IUserService _service;
        public LoginUserCommandHandler(IUserService service)
            => _service = service;

        public async Task<ApiResult<LoginResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Login(request.Request);

            return result;
        }
    }
}
