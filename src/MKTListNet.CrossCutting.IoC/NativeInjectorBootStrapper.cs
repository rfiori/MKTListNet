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
            // Infra - Data
            services.AddScoped<MKTListNetContext>();
            //services.AddScoped<IPagingResult<object>, PagingResult<object>>();
            services.AddScoped<IEmailRepository, EmailRepository>();
            services.AddScoped<IEmailListRepository, EmailListRepository>();
            services.AddScoped<IEmailEmailListRepository, EmailEmailListRepository>();

            // Domain
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IEmailListService, EmailListService>();
            services.AddScoped<IEmailEmailListService, EmailEmailListService>();

            // Application
            services.AddScoped<IEmailAppService, EmailAppService>();
            services.AddScoped<IEmailListAppService, EmailListAppService>();
            services.AddScoped<IEmailEmailListAppServive, EmailEmailListAppService>();
        }
    }
}