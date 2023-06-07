using AutoMapper;
using Business.Abstract;
using Core.Exceptions;
using Core.Utilities.Security.Token.Jwt;
using DataAccess.Abstracts;
using DataAccess.Dtos;
using DataAccess.Entities;
using static Core.Models.BaseResponseModel;

namespace Business.Concreate
{
    public class UserService : IUserService
    {
        private readonly IJwtService jwtService;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        public UserService(IMapper mapper, IJwtService jwtService, IUserRepository userRepository)
        {
            this.mapper = mapper;
            this.jwtService = jwtService;
            this.userRepository = userRepository;
        }
        public async Task<ServiceResponse<UserLoginResponseDto>> InsertAsync(UserInsertDto userInsertDto)
        {
            bool usernameIsUnique = await userRepository.UsernameIsUniqueAsync(userInsertDto.Username);
            if (usernameIsUnique)
            {
                var user = mapper.Map<User>(userInsertDto);
                var addedUser = await userRepository.AddAsync(user);
                if (addedUser != null)
                {
                    var userLoginDto = mapper.Map<UserLoginResponseDto>(user);
                    userLoginDto.Token = jwtService.CreateToken(user.Id);
                    return new ServiceResponse<UserLoginResponseDto>(userLoginDto);
                }
                else throw new InternalServerException("User registeration error !");
            }
            else throw new BadRequestException("Username must be unique !");
        }
    }
}
