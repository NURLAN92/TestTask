using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Application.Core;
using TestTask.Application.Interfaces;
using TestTask.Domain.Entities;
using TestTask.Domain.Enums;
using TestTask.Domain.Models.User.Get;
using TestTask.Domain.Models.User.Login;
using TestTask.Domain.Models.User.Register;
using TestTask.Infrastructure.Data;

namespace TestTask.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IJWTService _jwtService;
        public UserService(ApplicationDbContext context, IJWTService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<ApiResult<List<GetResponse>>> Get(GetRequest request)
        {
            var query = _context.Users.AsQueryable().AsNoTracking();

            if (request.Name != null)
                query = query.Where(x => x.Name == request.Name);

            if (request.Id != null)
                query = query.Where(x => x.Id == request.Id);

            var users = await query.Select(x => new GetResponse
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
            }).ToListAsync();

            return ApiResult<List<GetResponse>>.OK(users);
        }

        public async Task<ApiResult<GetResponse>> GetMe(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return ApiResult<GetResponse>.Error(ErrorCodes.DATA_NOT_FOUND);

            var response = new GetResponse
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
            };

            return ApiResult<GetResponse>.OK(response);  
        }

        public async Task<ApiResult<LoginResponse>> Login(LoginRequest request)
        {
            var user = await _context.Users.Where(x => x.Name == request.Name).FirstOrDefaultAsync();

            if (user == null)
                return ApiResult<LoginResponse>.Error(ErrorCodes.EMAIL_OR_PASSWORD_IS_NOT_CORRECT);

            bool check = user.CheckPassword(request.Password);

            if (!check)
                return ApiResult<LoginResponse>.Error(ErrorCodes.EMAIL_OR_PASSWORD_IS_NOT_CORRECT);

            var token = _jwtService.GenerateJwtToken(user.Id, user.Email);

            var response = new LoginResponse
            {
                AccessToken = token
            };

            return ApiResult<LoginResponse>.OK(response);
        }

        public async Task<ApiResult<RegisterResponse>> Register(RegisterRequest request)
        {
            var existUser = await _context.Users.AnyAsync(x => x.Name == request.Name ||  x.Email == request.Email);

            if (existUser)
                return ApiResult<RegisterResponse>.Error(ErrorCodes.USER_ALREADY_EXISTS);

            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address
            };

            newUser.AddPassword(request.Password);

            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            var response = new RegisterResponse
            {
                Message = "User successfully registered."
            };

            return ApiResult<RegisterResponse>.OK(response);
        }
    }
}
