using AutoMapper;
using DataAccess.Dtos;
using DataAccess.Entities;

namespace Business.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<User, UserLoginResponseDto>();
        }
    }
}
