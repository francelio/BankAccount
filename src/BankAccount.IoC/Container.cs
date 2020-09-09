using System;
using BankAccount.Domain.ContextCurrentAccount.Repositories;
using BankAccount.InfraStructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankAccount.IoC
{
	public static class Container
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddMediatr();
            return services;
        }

        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration["ConnectionString"], b => b.MigrationsAssembly("BankAccount.Api")));
            services.AddScoped<IAccountRepository, AccountRepository>(); 
        }
        private static void AddMediatr(this IServiceCollection services)
        {
           var assembly = AppDomain.CurrentDomain.Load("BankAccount.Domain");

          //  services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestsValidationMiddleware<,>));
            services.AddMediatR(assembly);
        }
    }
}
