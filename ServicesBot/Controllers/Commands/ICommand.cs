using Telegram.Bot;
using Telegram.Bot.Types;

namespace ServicesBot.Controllers.Commands
{
    public interface ICommandss
    {
        
        //public async Task Execute(Update update) { }

        Task Execute(ITelegramBotClient botClient, Message message);
    }
}
