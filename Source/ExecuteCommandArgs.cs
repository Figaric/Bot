using Telegram.Bot;
using Telegram.Bot.Types;

namespace DotaBot
{
    public class ExecuteCommandArgs
    {
        public ITelegramBotClient Bot { get; init; }

        public Message Message { get; init; }

        public string Argument { get; init; }
    }
}