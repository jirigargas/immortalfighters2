using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Models;
using System.Linq;
using BC = BCrypt.Net.BCrypt;

namespace ImmortalFighters.WebApp.Services
{
    public interface IUsersService
    {
        IResponse<LoginResponse> Authenticate(LoginRequest request);
        IResponse Register(RegisterRequest request);
        User GetById(int id);
    }

    public class UsersService : IUsersService
    {
        private readonly IfDbContext _context;
        private readonly IAuthenticationProvider _authenticationProvider;

        public UsersService(IfDbContext context, IAuthenticationProvider authenticationProvider)
        {
            _context = context;
            _authenticationProvider = authenticationProvider;
        }

        public IResponse<LoginResponse> Authenticate(LoginRequest request)
        {
            var user = _context.Users.SingleOrDefault(x => x.Email == request.Email);

            if (user == null) return Response<LoginResponse>.InvalidResponse("Authentication failed");

            var isPasswordValid = BC.Verify(request.Password, user.Password);

            if (!isPasswordValid) return Response<LoginResponse>.InvalidResponse("Authentication failed");

            var token = _authenticationProvider.GetToken(user);

            return Response<LoginResponse>.ValidResponse(new LoginResponse
            {
                Token = token,
                Username = user.Password
            });
        }

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public IResponse Register(RegisterRequest request)
        {
            if (!request.IsValid()) return Response.InvalidResponse("Request data is not valid");

            var existingUser = _context.Users.FirstOrDefault(x => x.Email == request.Email);
            if (existingUser != null) return Response.InvalidResponse("Email is already being used");

            var hashPassword = BC.HashPassword(request.Password);
            var user = new User
            {
                Username = request.Username,
                Password = hashPassword,
                Email = request.Email
            };
            _context.Users.Add(user);
            _context.SaveChanges();

            return Response.ValidResponse();
        }
    }
}
