using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Core;
using TestTask.Domain.Models.User.Get;
using TestTask.Domain.Models.User.Login;
using TestTask.Domain.Models.User.Register;

namespace TestTask.Application.Interfaces
{
    public interface IUserService
    {
        Task<ApiResult<RegisterResponse>> Register(RegisterRequest request);
        Task<ApiResult<LoginResponse>> Login(LoginRequest request);
        Task<ApiResult<List<GetResponse>>> Get(GetRequest request);
        Task<ApiResult<GetResponse>> GetMe(Guid id);
    }
}
