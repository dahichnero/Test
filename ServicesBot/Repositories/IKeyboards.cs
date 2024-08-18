using ServicesBot.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServicesBot.Repositories
{
    public interface IKeyboards
    {
        InlineKeyboardButton[][] CreateKeyboardServices(List<ServiceSubs> serviceSubs);
        InlineKeyboardButton[][] CreateKeyboardChangeStop(UserPeriod userPeriod);

        InlineKeyboardButton[][] CreateKeyboardRestart(UserPeriod userPeriod);

        InlineKeyboardButton[][] CreateKeyboardPeriods(List<Period> periods);

        InlineKeyboardButton[][] CreateKeyboardServicesNew(int idServices);

        InlineKeyboardButton[][] CreateKeyboardPay(int idPeriod);
    }
}
