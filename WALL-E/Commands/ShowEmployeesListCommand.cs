using WALL_E.Core;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace WALL_E.Commands
{
    /// <summary>
    /// Отображает список сотрудников для просмотра информации о них
    /// </summary>
    internal class ShowEmployeesListCommand : TelegramCommand
    {
        /// <summary>
        /// Отображает список сотрудников для просмотра информации о них
        /// </summary>
        public ShowEmployeesListCommand() { }

        public override string Name => "Список сотрудников";

        public override async Task Execute(Message message, ITelegramBotClient botClient, CancellationToken token)
        {
            InlineKeyboardMarkup employeesList = new InlineKeyboardMarkup(Program.OrganizationInstance.Employees
                    .Select(employee =>
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData(employee.FullName, employee.Position.ToString())
                        }));

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new KeyboardButton("Меню")) { ResizeKeyboard = true };

            await botClient.SendTextMessageAsync(message.Chat.Id,
                                     "Выберите должность для просмотра информации о ней:",
                                     replyMarkup: employeesList,
                                     cancellationToken: token);

            await botClient.SendTextMessageAsync(message.Chat.Id, "Или вернитесь назад", replyMarkup: keyboard, cancellationToken: token);
        }
    }
}