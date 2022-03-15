using Microsoft.Extensions.Configuration;

namespace GISA.Core.Utils
{
    public static class ConfigurationExtensions
    {
        public static string GetMessageQueueConnection(this IConfiguration configuration, string name)
            => configuration?.GetSection("MessageQueueConnection")?[name];
    }
}