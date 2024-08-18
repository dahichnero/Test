using Telegram.Bot.Types;

namespace ServicesBot.Repositories
{
    public interface ITelegramCallBackQuery
    {
       Task HandleCallbackQuery(CallbackQuery callbackQuery, long chatId);
    }
}
