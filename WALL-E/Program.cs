using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;

namespace WALL_E
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new TelegramBotClient("5827074806:AAF3EYoa3QX7T-xINZPFCVaJYm38x7Lg8u0")
                .StartReceiving(Update, Error);
            Console.ReadKey(true);
        }

        private static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            Message? message = update.Message;
            if (!string.IsNullOrWhiteSpace(message?.Text))
            {
                if (message.Text.ToLower() == "lemonchello")
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Ты");
                    //using (FileStream fs = new FileStream("", FileMode.))
                    //{

                    //}
                    //await botClient.SendPhotoAsync(message.Chat.Id, new InputOnlineFile());
                }
            }
        }

        private static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3) => new(() => { });
    }
}