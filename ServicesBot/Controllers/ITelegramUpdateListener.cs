using Telegram.Bot.Types;

namespace ServicesBot.Controllers
{
    public interface ITelegramUpdateListener
    {
        Task HandleUpdateAsync(Update update);
    }
}
