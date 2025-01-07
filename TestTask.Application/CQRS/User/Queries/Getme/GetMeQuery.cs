using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Core;
using TestTask.Domain.Models.User.Get;

namespace TestTask.Application.CQRS.User.Queries.Getme
{
    public class GetMeQuery : IRequest<ApiResult<GetResponse>>
    {
        public Guid Id { get; set; }

        public GetMeQuery(Guid id)
            => Id = id;
    }
}
