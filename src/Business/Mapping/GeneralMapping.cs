using AutoMapper;
using Core.Utilities.Helpers;
using DataAccess.Dtos.Product;
using DataAccess.Dtos.User;
using DataAccess.Entities;

namespace Business.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<User, UserLoginResponseDto>();
            // Mapping will encryp password
            CreateMap<UserInsertDto, User>()
                .ForMember(d => d.Password, o => o.MapFrom(s => MD5HashHelper.Create(s.Password)));
            CreateMap<ProductInsertDto, Product>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => FileHelper.FileToByteArray(src.Image)))
                .AfterMap((src, dest) => { if (src.Image == null) dest.Image = null; })
                .ForMember(dest => dest.ImageType, opt => opt.MapFrom(src => src.Image != null ? src.Image!.ContentType : null));
            CreateMap<ProductUpdateDto, Product>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => FileHelper.FileToByteArray(src.Image)))
                .AfterMap((src, dest) => { if (src.Image == null) dest.Image = null; })
                .ForMember(dest => dest.ImageType, opt => opt.MapFrom(src => src.Image != null ? src.Image!.ContentType : null));
            CreateMap<Product, ProductResponseDto>()
                .AfterMap((src, dest) => { if (src.Image == null) dest.Image = null; });
        }
    }
}
