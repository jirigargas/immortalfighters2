using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.MediatR;
using ImmortalFighters.WebApp.Models;
using MediatR;
using System;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace ImmortalFighters.WebApp.Services
{
    public interface IUsersService
    {
        LoginResponse Authenticate(LoginRequest request);
        Task<User> Register(RegisterRequest request);
        User GetById(int id);
    }

    public class UsersService : IUsersService
    {
        private readonly IfDbContext _context;
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IMediator _mediator;

        public UsersService(IfDbContext context, IAuthenticationProvider authenticationProvider, IMediator mediator)
        {
            _context = context;
            _authenticationProvider = authenticationProvider;
            _mediator = mediator;
        }

        public LoginResponse Authenticate(LoginRequest request)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == request.Email);

            if (user == null) throw new ApiResponseException { StatusCode = 400, ClientMessage = "Tebe neznám" };

            var isPasswordValid = BC.Verify(request.Password, user.Password);

            if (!isPasswordValid) throw new ApiResponseException { StatusCode = 400, ClientMessage = "Tebe neznám" };

            var token = _authenticationProvider.GetToken(user);

            return new LoginResponse
            {
                Token = token,
                Username = user.Username
            };
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public async Task<User> Register(RegisterRequest request)
        {
            if (!request.IsValid()) throw new ApiResponseException { StatusCode = 400 };

            var userWithSameEmail = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (userWithSameEmail != null)
                throw new ApiResponseException { StatusCode = 400, ClientMessage = "Zadaný email už se používá" };

            var userWithSameUsername = _context.Users.FirstOrDefault(x => x.Username == request.Username);
            if (userWithSameUsername != null)
                throw new ApiResponseException { StatusCode = 400, ClientMessage = "Zadané jméno už se používá" };

            var hashPassword = BC.HashPassword(request.Password);
            var user = new User
            {
                Username = request.Username,
                Password = hashPassword,
                Email = request.Email,
                Created = DateTime.UtcNow,
                Status = AccountStatus.NotVerified
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            var message = new RegistrationEmailMessage(user);
            await _mediator.Publish(new SendEmail { Message = message.BuildMessage() });

            return user;
        }
    }
}
