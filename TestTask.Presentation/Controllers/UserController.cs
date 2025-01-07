using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Application.Core;
using TestTask.Application.CQRS.User.Commads.Login;
using TestTask.Application.CQRS.User.Commads.Register;
using TestTask.Application.CQRS.User.Queries.Get;
using TestTask.Application.CQRS.User.Queries.Getme;
using TestTask.Domain.Models.User.Get;
using TestTask.Domain.Models.User.Login;
using TestTask.Domain.Models.User.Register;

namespace TestTask.Presentation.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
            => _mediator = mediator;


        [HttpPost("register")]
        public async Task<ActionResult<ApiResult<RegisterResponse>>> Register([FromForm] RegisterRequest request)
            => await _mediator.Send(new RegisterUserCommand(request));

        [HttpPost("login")]
        public async Task<ActionResult<ApiResult<LoginResponse>>> Login([FromForm] LoginRequest request)
            => await _mediator.Send(new LoginUserCommand(request));

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<ApiResult<List<GetResponse>>>> Get([FromQuery] GetRequest request)
            => await _mediator.Send(new GetUserQuery(request));

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<ApiResult<GetResponse>>> GetMe()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");

            var id = Guid.TryParse(userIdClaim.Value, out Guid userId);

            return await _mediator.Send(new GetMeQuery(userId));

        }


    }
}
