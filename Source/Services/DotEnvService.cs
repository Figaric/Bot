using System;

namespace DotaBot
{
    public class DotEnvService
    {
        public string BotToken => Environment.GetEnvironmentVariable(nameof(BotToken));
    }
}