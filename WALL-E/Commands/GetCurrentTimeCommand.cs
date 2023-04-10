using WALL_E.Core;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace WALL_E.Commands
{
    internal class GetCurrentTimeCommand : TelegramCommand
    {
        public override string Name { get; } = "Скажи время";

        public override async Task Execute(Message message, ITelegramBotClient botClient)
        {
            string text = "Текущее время: " + DateTime.Now;

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