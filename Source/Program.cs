using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using dotenv.net;
using DotaBot;
using Telegram.Bot.Types;
using System.Threading.Tasks;
using System.Threading;
using System;
using Telegram.Bot.Exceptions;

DotEnv.Load();
var dotEnvService = new DotEnvService();

ITelegramBotClient bot = new TelegramBotClient(dotEnvService.BotToken);
var commandService = new CommandService();

bot.ReceiveAsync(
    new DefaultUpdateHandler(HandleUpdate, HandleError)
);

async Task HandleUpdate(ITelegramBotClient bot, Update update, CancellationToken token)
{
    if (!(update.Message is Message message))
        return;

    char prefix = '/';

    if (!message.Text.StartsWith(prefix))
        return;

    string[] parts = message.Text.Split(' ');

    string commandName = parts[0].Substring(1); // /hello -> hello
    string arg = parts[1];

    var exeArgs = new ExecuteCommandArgs
    {
        Bot = bot,
        Argument = arg,
        Message = message
    };

    await commandService.HandleCommand(commandName, exeArgs);
}

async Task HandleError(ITelegramBotClient bot, Exception exception, CancellationToken token)
{
    await bot.SendTextMessageAsync(
        chatId: 123,
        text: "Something went wrong"
    );
}

// Console.WriteLine("BotToken: " + dotEnvService.BotToken);