using WALL_E.Core;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InputFiles;

namespace WALL_E.Commands
{
    internal class PassAnyStickerCommand : TelegramCommand
    {
        static PassAnyStickerCommand() => _random = new Random();

        private static readonly Random _random;

        private readonly string[] _stickerBase = new string[]
        {
            "CAACAgIAAxkBAAEIiHlkNFTkm3dDooPfR9cZE-nnX-fXMwAC-hgAAlCx6Un0hgVIhUGOVi8E",
            "CAACAgIAAxkBAAEIiHtkNFVX1fHNAkDNAkexJPQ2ZHfxlgACoxgAArvwwEuKzMnbs96XFy8E",
            "CAACAgIAAxkBAAEIiH1kNFV3sfAKZ1kH57s3M-ylr_YvpQACIBUAAoIu4Ep6kj0HR5GKGC8E",
            "CAACAgQAAxkBAAEIiH9kNFa1PLx_BsXEereWAAFWNCVoH6IAAm0LAAKmvrFTHfcUKlxYF6MvBA"
        };

        public override string Name { get; } = "Отправь стикер";

        public override async Task Execute(Message message, ITelegramBotClient botClient)
        {
            InputOnlineFile file = new InputOnlineFile(_stickerBase[_random.Next(0, _stickerBase.Length)]);

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

            await botClient.SendStickerAsync(message.Chat.Id, file, replyMarkup: keyboard);
        }
    }
}