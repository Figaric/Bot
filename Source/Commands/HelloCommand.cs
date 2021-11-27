using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DotaBot
{
    public class HelloCommand : ICommand
    {
        public string Name { get; init; }

        public async Task ExecuteAsync(ExecuteCommandArgs args)
        {
            var message = args.Message;
            var bot = args.Bot;

            var chatId = message.Chat.Id;

            await bot.SendTextMessageAsync(
                chatId: chatId,
                text: message.Text
            );
        }
    }
}