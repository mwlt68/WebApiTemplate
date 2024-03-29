﻿using AutoMapper;
using Core.Utilities.Helpers;
using DataAccess.Dtos;
using DataAccess.Entities;

namespace Business.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<User, UserLoginResponseDto>();
            // Mapping will encryp password
            CreateMap<UserInsertDto, User>().ForMember(d => d.Password, o => o.MapFrom(s => MD5HashHelper.Create(s.Password)));
        }
    }
}
