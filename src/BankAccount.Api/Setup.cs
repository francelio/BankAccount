using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using MediatR;
using System.Reflection;

namespace BankAccount.Api
{
	public static class Setup
	{
		public static void ConfigureSwagger(this IServiceCollection services)
		{

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1",
					new OpenApiInfo
					{
						Title = "Documentação da API",
						Version = "v1",
						Description = "Está API é ultilizada para teste",
						Contact = new OpenApiContact
						{
							Name = "Francélio Alencar",
							Email = "francelio.si@gmail.com"
						}
					});

				//c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				//{
				//	Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
				//	Name = "Authorization",
				//	In = ParameterLocation.Header,
				//	Type = SecuritySchemeType.ApiKey,
				//	Scheme = "Bearer"
				//});

				//c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				//{
				//	{
				//		new OpenApiSecurityScheme
				//		{
				//			Reference = new OpenApiReference
				//			{
				//				Type = ReferenceType.SecurityScheme,
				//				Id = "Bearer"
				//			},
				//			Scheme = "oauth2",
				//			Name = "Bearer",
				//			In = ParameterLocation.Header,

				//		},
				//		new List<string>()
				//	}
				//});

				var caminhoAplicacao = AppContext.BaseDirectory;
				var nomeAplicacao = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
				var caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

				c.IncludeXmlComments(caminhoXmlDoc);
			});
		}

		public static void ConfigureCors(this IServiceCollection services) => services.AddCors(options =>
																			  {
																				  options.AddPolicy("CorsPolicy",
																					  builder => builder.AllowAnyOrigin()
																					  .AllowAnyMethod()
																					  .AllowAnyHeader()
																					  .AllowCredentials());
																			  });

		public static void ConfigureCookie(this IServiceCollection services) => services.Configure<CookiePolicyOptions>(options =>
																				{
																					options.CheckConsentNeeded = context => true;
																					options.MinimumSameSitePolicy = SameSiteMode.None;
																				});

		public static void ConfigureMediatR(this IServiceCollection services)
		{
			services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
		}
	}
}
