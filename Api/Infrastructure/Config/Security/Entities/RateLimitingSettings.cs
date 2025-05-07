namespace Api.Infrastructure.Config.Security.Entities
{
    public class RateLimitingSettings
    {
        public int InternalPermitLimit { get; set; } = 100;
        public int InternalWindowSeconds { get; set; } = 60;
        public int InternalQueueLimit { get; set; } = 0;

        public int IPPermitLimit { get; set; } = 60;
        public int IPWindowSeconds { get; set; } = 60;
        public int IPSegments { get; set; } = 6;
        public int IPQueueLimit { get; set; } = 0;
    }
}
