using ServicesBot.Models;
using ServicesBot.Repositories.Realizations;
using System.Numerics;
using System.Xml.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServicesBot.Controllers.Commands
{
    public class ServicesCommand : ICommandss
    {
        private ServicesSubsContext _subsContext;
        public ServicesCommand(ServicesSubsContext subsContext)
        {
            _subsContext = subsContext;
        }

        public async Task Execute(ITelegramBotClient botClient, Message message)
        {
            AllMessages allMessages=new AllMessages();
            DatabaseService databaseService=new DatabaseService();
            KeyboardsFor keyboardsFor=new KeyboardsFor();
            var keyboard = new ReplyKeyboardMarkup(new[]
            {
                new KeyboardButton("Назад в главное меню"),
            });
            var inlinekey = new InlineKeyboardMarkup(keyboardsFor.CreateKeyboardServices(databaseService.GetServiceSubs(_subsContext)));
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: allMessages.NewServices(), replyMarkup: keyboard);
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, text: allMessages.CheckNewServices(), replyMarkup: inlinekey);
        }

        /*private List<ServiceSubs> GetServiceSubs()
        {
            List<ServiceSubs> serviceSubs = _subsContext.Services.ToList();
            return serviceSubs;
        }
        private InlineKeyboardButton[][] CreateKeyboard(List<ServiceSubs> serviceSubs)
        {
            var buttons=new List<InlineKeyboardButton[]>();
            foreach (var ser in serviceSubs)
            {
                buttons.Add(new[] {InlineKeyboardButton.WithCallbackData(ser.ServiceName, $"service_{ser.ServiceSubsId}")});
            }
            return buttons.ToArray();
        }*/

    }
}
