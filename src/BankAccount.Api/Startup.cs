using AutoMapper;
using BankAccount.IoC;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BankAccount.Api
{
	public class Startup
    {
        public Startup(IConfiguration configuration)
        {
			this.configuration = configuration;
        }

		private readonly IConfiguration configuration;

		public IConfiguration GetConfiguration()
		{
			return configuration;
		}

		public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.ConfigureSwagger();
            services.AddAutoMapper();
            services.AddApplicationServices(GetConfiguration());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
           // app.UseAuthorization();

            app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api");
				c.RoutePrefix = "doc";
            });

			app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }


    }
}
