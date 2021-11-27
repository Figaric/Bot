using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace DotaBot
{
    public interface ICommand
    {
        public string Name { get; init; }

        Task ExecuteAsync(ExecuteCommandArgs args);
    }
}