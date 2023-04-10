namespace WALL_E.Core
{
    /// <summary>
    /// Предоставляет базовый функционал, необходимый для реализации объекта управления командами
    /// </summary>
    internal interface ICommandService
    {
        /// <summary>
        /// Возвращает список команд
        /// </summary>
        /// <returns>Возвращает <see cref="IEnumerable{T}"/>, где <see langword="T"/> — <see cref="TelegramCommand"/></returns>
        IEnumerable<TelegramCommand> Get();
    }
}