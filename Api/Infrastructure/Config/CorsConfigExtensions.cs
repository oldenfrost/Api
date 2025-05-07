namespace Api.Infrastructure.Config
{
    public static class CorsConfigExtensions
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services, IConfiguration config) 
        { 
            var allowedOrigins = config.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
            services.AddCors(options =>
            {
                options.AddPolicy("CustomCorsPolicy", builder =>
                {
                    if(allowedOrigins.Length == 1 && allowedOrigins[0]=="*")
                    {
                        builder.SetIsOriginAllowed(_ => true);
                    }
                    else
                    {
                        builder.WithMethods(allowedOrigins);
                    }
                    builder.AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetPreflightMaxAge(TimeSpan.FromSeconds(10));


                });

               
            });
            return services;

        }
    }
}
