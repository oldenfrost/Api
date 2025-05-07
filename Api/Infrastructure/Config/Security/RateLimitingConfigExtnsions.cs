using Api.Infrastructure.Config.Security.Entities;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;


namespace Api.Infrastructure.Config.Security
{
    public static class RateLimitingConfigExtnsions
    {
        public static IServiceCollection AddCustomRateLimiting(this IServiceCollection services, IConfiguration configuration)
        {

            var rateLimitSettings = configuration.GetSection("RateLimiting").Get<RateLimitingSettings>();
            services.AddRateLimiter(options =>
            {
                options.AddFixedWindowLimiter("FixedWindowBasic", config =>
                {
                    config.PermitLimit = rateLimitSettings.InternalPermitLimit;
                    config.Window = TimeSpan.FromSeconds(rateLimitSettings.InternalWindowSeconds);
                    config.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                    config.QueueLimit = rateLimitSettings.InternalPermitLimit;


                });

                options.AddSlidingWindowLimiter("SlidingWindowByIP", config =>
                {
                    config.PermitLimit = rateLimitSettings.IPPermitLimit;
                    config.Window = TimeSpan.FromSeconds(rateLimitSettings.IPWindowSeconds);
                    config.SegmentsPerWindow = rateLimitSettings.IPSegments;
                    config.QueueLimit = rateLimitSettings.IPQueueLimit;

                });
                options.OnRejected = async (context, cancellationToken) =>
                {
                    context.HttpContext.Response.Headers["Retry-After"] = "5";
                    await context.HttpContext.Response.WriteAsync(
                    "Too many requests. Please try again later.", cancellationToken);
                };
                options.RejectionStatusCode = 429;
            });
            return services;

        }
    }
}
