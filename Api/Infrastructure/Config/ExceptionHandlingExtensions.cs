using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

namespace Api.Infrastructure.Config
{
    public static class ExceptionHandlingExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHander(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                return app;
            }
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var feature = context.Features.Get<IExceptionHandlerFeature>();
                    var error = feature?.Error;
                    var response = new
                    {
                        message = "Ocurrio un error Inesperado",
                        detail = error?.Message,
                        path = context.Request.Path,
                        strackTrace = env.IsDevelopment()? error.StackTrace:null
                    };
                    context.Response.ContentType = "application/json";

                    context.Response.StatusCode = error switch
                    {
                        ArgumentNullException _ => StatusCodes.Status400BadRequest,
                        UnauthorizedAccessException _ => StatusCodes.Status401Unauthorized,
                        _ => StatusCodes.Status500InternalServerError
                    };
                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));

                });

            });

            return app;

        }

    }
}
