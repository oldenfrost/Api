
using Api.Infrastructure.Config;
using Api.Infrastructure.Config.Security;
using Api.Infrastructure.Config.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomSwagger();   
builder.Services.AddJwtSwagger();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddCustomCors(builder.Configuration);

builder.Services.AddCustomResponseCompression(builder.Configuration);

builder.Services.AddCustomRateLimiting(builder.Configuration);

builder.Services.AddInjectionServices();

builder.Services.AddControllers();

var app = builder.Build();

app.UseGlobalExceptionHander(app.Environment);

app.UseResponseCompression();

app.UseCors("CustomCorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = string.Empty;
    });
}

    app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
