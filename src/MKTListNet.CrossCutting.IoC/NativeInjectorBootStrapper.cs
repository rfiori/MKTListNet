using Microsoft.Extensions.DependencyInjection;
using MKTListNet.Application.Interface;
using MKTListNet.Application.Services;
using MKTListNet.Data.Repository;
using MKTListNet.Domain.Interface.Repository;
using MKTListNet.Domain.Interface.Services;
using MKTListNet.Domain.Services;

namespace MKTListNet.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain
            services.AddScoped<IEmailService, EmailService>();

            //Application
            services.AddScoped<IEmailAppService, EmailAppService>();

            // Ifra - Data
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmailListRepository, EmailListRepository>();
        }
    }
}