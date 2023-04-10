using WALL_E.Core;
using WALL_E.Model;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;

namespace WALL_E
{
    internal sealed class Program
    {
        private static readonly ICommandService _commandService;

        static Program() => _commandService = new CommandService();

        private static void Main()
        {
            TelegramBotClient botClient = new TelegramBotClient("5827074806:AAF3EYoa3QX7T-xINZPFCVaJYm38x7Lg8u0");

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

            foreach (TelegramCommand? command in _commandService.Get().Where(c => c.Equals(message)))
            {
                await command.Execute(message, botClient);
                break;
            }
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