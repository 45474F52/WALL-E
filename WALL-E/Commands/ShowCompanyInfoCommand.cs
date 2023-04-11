using WALL_E.Core;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace WALL_E.Commands
{
    /// <summary>
    /// Предоставляет информацию об организации
    /// </summary>
    internal class ShowCompanyInfoCommand : TelegramCommand
    {
        /// <summary>
        /// Предоставляет информацию об организации
        /// </summary>
        public ShowCompanyInfoCommand() { }

        public override string Name => "О компании";    

        public override async Task Execute(Message message, ITelegramBotClient botClient, CancellationToken token)
        {
            string text =
                Program.OrganizationInstance.Name + Environment.NewLine + Environment.NewLine + Program.OrganizationInstance.Description;

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new[]
                {
                    new[]
                    {
                        new KeyboardButton("Список сотрудников")
                    },
                    new[]
                    {
                        new KeyboardButton("Меню")
                    }
                })
            { ResizeKeyboard = true };

            await botClient.SendTextMessageAsync(message.Chat.Id, text, replyMarkup: keyboard, cancellationToken: token);
        }
    }
}