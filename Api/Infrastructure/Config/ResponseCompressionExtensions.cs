using Microsoft.AspNetCore.ResponseCompression;

namespace Api.Infrastructure.Config
{
    public static class ResponseCompressionExtensions
    {
        public static IServiceCollection AddCustomResponseCompression(this IServiceCollection services, IConfiguration config)
        {
            var settings = config.GetSection("ResponseCompression").Get<ResponseCompression>()?? new ResponseCompression();
            services.AddResponseCompression(options =>
            {
                options.Providers.Clear();
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
                options.MimeTypes = settings.MimeTypes;
                options.EnableForHttps = settings.EnableForHttps;
            });
            services.Configure<BrotliCompressionProviderOptions>(opts =>
            {
                opts.Level = settings.BrotliLevel;

            });
            services.Configure<GzipCompressionProviderOptions>(opts =>
            {
                opts.Level = settings.GzipLevel;
            });

            return services;
        }



    }
}
