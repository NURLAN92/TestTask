using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Core;
using TestTask.Domain.Models.User.Register;

namespace TestTask.Application.CQRS.User.Commads.Register
{
    public class RegisterUserCommand : IRequest<ApiResult<RegisterResponse>>
    {
        public RegisterRequest Request { get; set; }

        public RegisterUserCommand(RegisterRequest request)
            => Request = request;
    }
}
