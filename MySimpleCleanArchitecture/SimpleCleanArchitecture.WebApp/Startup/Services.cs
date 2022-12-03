using System.Reflection;
using MediatR;
using MediatR.Pipeline;
using SimpleCleanArchitecture.Application.Contracts.Repository;
using SimpleCleanArchitecture.Application.Services.Email;
using SimpleCleanArchitecture.Infrastructure;
using SimpleCleanArchitecture.Infrastructure.Email;
using SimpleCleanArchitecture.Infrastructure.EntityFramework;
using SimpleCleanArchitecture.WebApp.Startup;
namespace SimpleCleanArchitecture.WebApp.Startup
{
    public static class Services
    {
        public static void Add(IServiceCollection services, IWebHostEnvironment env, IConfiguration configuration)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            #region Services

            services.AddDbContext(configuration.GetConnectionString("Default"));
           
            services.AddMediatRServices();
            services.AddScoped<IEmailSender, FakeEmailSender>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
           
            #endregion
        }
    }
}
