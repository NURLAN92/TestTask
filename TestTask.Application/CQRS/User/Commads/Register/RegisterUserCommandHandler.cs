using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Core;
using TestTask.Application.Interfaces;
using TestTask.Domain.Models.User.Register;

namespace TestTask.Application.CQRS.User.Commads.Register
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApiResult<RegisterResponse>>
    {
        private readonly IUserService _service;
        public RegisterUserCommandHandler(IUserService service)
            => _service = service;

        public async Task<ApiResult<RegisterResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.Register(request.Request);

            return result;
        }
    }
}
