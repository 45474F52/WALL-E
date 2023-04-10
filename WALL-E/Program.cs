using WALL_E.Core;
using WALL_E.Model;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using System.Configuration;

namespace WALL_E
{
    internal sealed class Program
    {
        private static readonly ICommandService _commandService;

        static Program() => _commandService = new CommandService();

        private static void Main()
        {
            string token = ConfigurationManager.AppSettings["Token"] ?? throw new ArgumentNullException("Токен не найден");
            TelegramBotClient botClient = new TelegramBotClient(token);

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                ReceiverOptions receiverOptions = new ReceiverOptions() { AllowedUpdates = Array.Empty<UpdateType>() };
                botClient.StartReceiving(
                    updateHandler: HandleUpdateAsync,
                    pollingErrorHandler: HandlePollingErrorAsync,
                    receiverOptions: receiverOptions,
                    cancellationToken: cts.Token);

                Console.WriteLine("READY");
                Console.ReadKey(true);
                cts.Cancel();
            }
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            if (update.Message is not { } message)
                return;

            TelegramCommand? command = _commandService.Get().FirstOrDefault(c => c.Equals(message));
            if (command != null)
                await command.Execute(message, botClient);
        }

        #region Обработка ошибок
        private static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {
            string ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException =>
                    $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }
        #endregion
    }
}