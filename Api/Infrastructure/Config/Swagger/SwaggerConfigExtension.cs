using System.Reflection;
using System.Runtime.CompilerServices;
using Microsoft.OpenApi.Models;

namespace Api.Infrastructure.Config.Swagger
{
    public static class SwaggerConfigExtension
    {
        public static IServiceCollection AddJwtSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Ingresa el token JWT prefijado con 'Bearer ' (sin comillas).",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                    },
                        Array.Empty<string>()
                    
                    }
                });
            });
            return services;
        }
        public static IServiceCollection AddCustomSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", CreaApiInfo());
                c.IncludeXmlComments(GetXmlCommentsPath());

            });
            return service;
        }
        private static OpenApiInfo CreaApiInfo() => new OpenApiInfo
        {
            Title = "Api",
            Version = "v1",
            Description = "Documentacion tecnica de la Api",


        };
        private static string GetXmlCommentsPath()
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            return Path.Combine(AppContext.BaseDirectory, xmlFile);
        }

    }
}
