using ImmortalFighters.WebApp.ApiModels;
using ImmortalFighters.WebApp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace ImmortalFighters.WebApp.Services
{
    public interface IAuthenticationService
    {
        LoginResponse Authenticate(LoginRequest request);

    }

    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationProvider _authenticationProvider;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IAuthenticationProvider authenticationProvider, IUserRepository userRepository)
        {
            _authenticationProvider = authenticationProvider;
            _userRepository = userRepository;
        }

        public LoginResponse Authenticate(LoginRequest request)
        {
            var user = _userRepository.GetBy(x => x.Email == request.Email);

            if (user == null) throw new ApiResponseException { StatusCode = 400, ClientMessage = "Tebe neznám" };

            var isPasswordValid = BC.Verify(request.Password, user.Password);

            if (!isPasswordValid) throw new ApiResponseException { StatusCode = 400, ClientMessage = "Tebe neznám" };

            var token = _authenticationProvider.GetToken(user);

            return new LoginResponse
            {
                Token = token,
                Username = user.Username,
                Roles = user.UserRoles.Select(x => x.Role.Name).ToList()
            };
        }
    }
}
