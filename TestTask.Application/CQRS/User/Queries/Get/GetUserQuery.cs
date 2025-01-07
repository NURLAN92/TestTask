using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Core;
using TestTask.Domain.Models.User.Get;

namespace TestTask.Application.CQRS.User.Queries.Get
{
    public class GetUserQuery : IRequest<ApiResult<List<GetResponse>>>
    {
        public GetRequest Request { get; set; }

        public GetUserQuery(GetRequest request)
            => Request = request;
        
    }
}
