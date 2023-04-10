using WALL_E.Core;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace WALL_E.Commands
{
    internal class MainCommand : TelegramCommand
    {
        public override string Name { get; } = "/start";

        public override async Task Execute(Message message, ITelegramBotClient botClient)
        {
            string text = "Бот WALL-E на связи!" + Environment.NewLine + Environment.NewLine + "Выбери команду:";

            ReplyKeyboardMarkup keyboard = new ReplyKeyboardMarkup(new[]
                {
                    new[]
                    {
                        new KeyboardButton("Выведи рандомное число")
                    },
                    new[]
                    {
                        new KeyboardButton("Скажи время")
                    },
                    new[]
                    {
                        new KeyboardButton("Отправь стикер")
                    }
                })
            { ResizeKeyboard = true };

            await botClient.SendTextMessageAsync(message.Chat.Id, text, replyMarkup: keyboard);
        }
    }
}