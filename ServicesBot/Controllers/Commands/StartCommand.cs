using ServicesBot.Models;
using ServicesBot.Repositories.Realizations;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServicesBot.Controllers.Commands
{
    public class StartCommand : ICommandss
    {
        public async Task Execute(ITelegramBotClient botClient, Message message)
        {
            AllMessages allMessages=new AllMessages();
            await botClient.SendTextMessageAsync(chatId: message.Chat.Id, 
                text: allMessages.Hello());
            
        }
    }
}
