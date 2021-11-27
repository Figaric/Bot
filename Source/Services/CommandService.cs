using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotaBot
{
    public class CommandService
    {
        private readonly IList<ICommand> _commands;

        public CommandService()
        {
            _commands = InitCommands();
        }

        private IList<ICommand> InitCommands()
        {
            var commandType = typeof(ICommand);

            IEnumerable<ICommand> commands = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => commandType.IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract)
                .Select(t => (ICommand)t);

            return commands.ToList();
        }

        public async Task HandleCommand(string commandName, ExecuteCommandArgs exeComArgs)
        {
            ICommand command = _commands.FirstOrDefault(c => c.Name == commandName);

            if (command is null)
                return;

            try
            {
                await command.ExecuteAsync(exeComArgs);
            }
            catch
            {
                Console.WriteLine("Something went wrong");
            }
        }
    }
}