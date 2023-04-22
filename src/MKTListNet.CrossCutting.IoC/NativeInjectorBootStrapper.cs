using Microsoft.Extensions.DependencyInjection;
using MKTListNet.Application.Interface;
using MKTListNet.Application.Services;
using MKTListNet.Domain.Interface.Repository;
using MKTListNet.Domain.Interface.Services;
using MKTListNet.Domain.Services;
using MKTListNet.Infra;
using MKTListNet.Infra.Repository;

namespace MKTListNet.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain
            services.AddScoped<IEmailService, EmailService>();

            // Application
            services.AddScoped<IEmailAppService, EmailAppService>();

            // Infra - Data
            services.AddScoped<MKTListNetContext>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmailListRepository, EmailListRepository>();
        }
    }
}