using MKTListNet.Application.AutoMapper;

namespace MKTListNet.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(ViewModelToDamoinMappingProfile), typeof(DomainToViewModelMappingProfile));
        }
    }
}
