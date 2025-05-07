using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;

namespace Api.Infrastructure.Config
{
    public class ResponseCompression
    {
        public bool EnableForHttps { get; set; } = true;
        public CompressionLevel BrotliLevel { get; set; } = CompressionLevel.Fastest;

        public CompressionLevel GzipLevel { get; set; } = CompressionLevel.Fastest;

        public string[] MimeTypes { get; set; } = ResponseCompressionDefaults.MimeTypes.ToArray();
    }
}
