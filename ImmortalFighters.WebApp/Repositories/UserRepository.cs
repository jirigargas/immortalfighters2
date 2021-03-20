using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using ImmortalFighters.WebApp.MediatR;
using ImmortalFighters.WebApp.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace ImmortalFighters.WebApp.Services
{
    public interface IUserRepository
    {
        Task<User> Register(RegisterRequest request);
        User GetBy(Func<User, bool> filter);
    }

    public class UserRepository : IUserRepository
    {
        private readonly IfDbContext _context;
        private readonly IMediator _mediator;

        public UserRepository(IfDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public User GetBy(Func<User, bool> filter)
        {
            return _context.Users
               .Include(x => x.UserRoles)
               .ThenInclude(x => x.Role)
               .SingleOrDefault(filter);
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

            var hashPassword = BC.HashPassword(request.Password); // TODO move to auth provider?!
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
