using WALL_E.Core;
using WALL_E.Commands;

namespace WALL_E.Model
{
    /// <summary>
    /// Представляет класс управления командами
    /// </summary>
    internal class CommandService : ICommandService
    {
        private readonly IEnumerable<TelegramCommand> _commands;

        /// <summary>
        /// Инициализирует список команд
        /// </summary>
        public CommandService()
        {
            _commands = new List<TelegramCommand>()
            {
                new MainCommand(),
                new RandomNumberCommand(),
                new GetCurrentTimeCommand(),
                new PassAnyStickerCommand(),
            };
        }

        public IEnumerable<TelegramCommand> Get() => _commands;
    }
}