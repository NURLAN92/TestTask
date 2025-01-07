using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Core;
using TestTask.Application.Interfaces;
using TestTask.Domain.Models.User.Get;

namespace TestTask.Application.CQRS.User.Queries.Getme
{
    public class GetMeQueryHandler : IRequestHandler<GetMeQuery, ApiResult<GetResponse>>
    {
        private readonly IUserService _service;
        public GetMeQueryHandler(IUserService service)
            => _service = service;

        public async Task<ApiResult<GetResponse>> Handle(GetMeQuery request, CancellationToken cancellationToken)
        {
            var result = await _service.GetMe(request.Id);

            return result;
        }
    }
}
