using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class AutoMapperExtension
    {
        public static void AddCustomAutoMapper(this IServiceCollection services, params Profile[] profiles)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                foreach (var p in profiles)
                {
                    mc.AddProfile(p);
                }
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
