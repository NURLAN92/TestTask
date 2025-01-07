using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Presentation.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        public IMediator Mediator { get => _mediator ?? HttpContext.RequestServices.GetRequiredService<IMediator>(); }
        private readonly IMediator _mediator;
    }
}
