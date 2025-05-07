namespace Api.Infrastructure.Config.Security
{
    public static class AuthenticationMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomAuthentication(this IApplicationBuilder app)
        { 
            app.UseAuthentication();
            app.UseAuthorization();
            return app;
        }

    }
}
