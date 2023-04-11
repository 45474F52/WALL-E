using WALL_E.Core;
using WALL_E.Model;
using WALL_E.Model.Entityes;
using WALL_E.Model.Entityes.Employees;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Polling;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using System.Text;
using System.Configuration;

namespace WALL_E
{
    internal static class Program
    {
        #region Organization Singleton
        private static readonly object locker = new object();
        private static volatile Organization _organization = null!;
        public static Organization OrganizationInstance
        {
            get
            {
                if (_organization is null)
                {
                    lock (locker)
                    {
                        _organization ??= new Organization(name: "ДА!", employees: new HashSet<Employee>()
                        {
                            new Director(Positions.Director),
                            new Administrator(Positions.Administrator),
                            new Supervisor(Positions.Supervisor),
                            new Operator(Positions.Operator_1C),
                            new Storekeeper(Positions.Storekeeper),
                            new Security(Positions.Security),
                            new Courier(Positions.Courier),
                            new Cashier(Positions.Cashier),
                            new Cleaner(Positions.Cleaner)
                        })
                        { Description = "Магазин ДА!" };
                    }
                }

                return _organization;
            }
        }
        #endregion

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

                botClient.OnApiResponseReceived += HandleAPIResponseAsync;
                botClient.OnMakingApiRequest += HandleAPIRequestAsync;

                Console.ReadKey(true);
                cts.Cancel();
            }
        }

        private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            Message? message = update.Message;
            CallbackQuery? callback = update.CallbackQuery;

            if (callback is not null)
            {
                if (message is not null)
                    message.Text = callback.Data;
                else if (message is null)
                    message = new Message() { Text = callback.Data, Chat = callback.Message!.Chat };
                else
                    return;
            }
            else if (update.Message is null)
                return;

            TelegramCommand? command = _commandService.Get().FirstOrDefault(c => c.Equals(message!));
            if (command != null)
                await command.Execute(message!, botClient, token);
            else
                await botClient.SendTextMessageAsync(message!.Chat.Id, $"Команда \"{message.Text}\" не реализована", cancellationToken: token);
        }

        #region Обработка API сообщений
        private static async ValueTask HandleAPIResponseAsync(ITelegramBotClient botClient, ApiResponseEventArgs e, CancellationToken token)
        {
            byte[] buffer = await e.ResponseMessage.Content.ReadAsByteArrayAsync(token);
            string content = Encoding.UTF8.GetString(buffer);
            ConsoleMessenger.Print("RESPONSE " + content + Environment.NewLine, MessageTypes.Warning);
        }

        private static async ValueTask HandleAPIRequestAsync(ITelegramBotClient botClient, ApiRequestEventArgs e, CancellationToken token)
        {
            string content = await e.HttpRequestMessage?.Content?.ReadAsStringAsync(token)! ?? "NULL";
            ConsoleMessenger.Print("REQUEST " + content + Environment.NewLine);
        }
        #endregion

        #region Обработка ошибок
        private static async Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception ex, CancellationToken token)
        {
            string errorMessage = ex is ApiRequestException requestException
                ? $"Telegram API Error:\n[{requestException.ErrorCode}]\n{requestException.Message}"
                : ex.ToString();

            ConsoleMessenger.Print(errorMessage, MessageTypes.Error);
            await Task.CompletedTask;
        }
        #endregion
    }
}