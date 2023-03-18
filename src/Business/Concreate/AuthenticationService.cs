using AutoMapper;
using Business.Abstract;
using Core.Utilities.Helpers;
using Core.Utilities.Responses;
using Core.Utilities.Security.Token.Jwt;
using DataAccess.Abstracts;
using DataAccess.Dtos.User;

namespace Business.Concreate
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtService jwtService;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public AuthenticationService(IMapper mapper, IJwtService jwtService, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.jwtService = jwtService;
            this.userRepository = userRepository;
        }
        public async Task<DataResponseModel<UserLoginResponseDto>> AuthenticateAsync(string username, string password)
        {
            string hashedPassword = MD5HashHelper.Create(password);
            var user = await userRepository.GetUserAsync(username, hashedPassword);
            if (user != null)
            {
                var userLoginDto = mapper.Map<UserLoginResponseDto>(user);
                userLoginDto.Token = jwtService.CreateToken(user.Id);
                return new DataResponseModel<UserLoginResponseDto>(userLoginDto);
            }
            else throw new KeyNotFoundException("Username or password wrong !");
        }
    }
}
