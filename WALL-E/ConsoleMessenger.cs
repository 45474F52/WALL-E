namespace WALL_E
{
    /// <summary>
    /// Обрабатывает сообщения для отображения в консоли
    /// </summary>
    internal static class ConsoleMessenger
    {
        /// <summary>
        /// Отправляет сообщение в консоль
        /// </summary>
        /// <remarks>От типа сообщения зависит цвет текста в консоли</remarks>
        /// <param name="text">Текст сообщения</param>
        /// <param name="messageType">Тип сообщения. По умолчанию равен <see cref="MessageTypes.Info"/></param>
        public static void Print(string text, MessageTypes messageType = MessageTypes.Info)
        {
            Console.ForegroundColor = (ConsoleColor)messageType;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }

    /// <summary>
    /// Типы сообщений
    /// </summary>
    internal enum MessageTypes
    {
        /// <summary>
        /// Информация
        /// </summary>
        Info = ConsoleColor.Blue,

        /// <summary>
        /// Предупреждение
        /// </summary>
        Warning = ConsoleColor.DarkYellow,

        /// <summary>
        /// Ошибка
        /// </summary>
        Error = ConsoleColor.Red
    }
}