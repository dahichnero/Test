using ServicesBot.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace ServicesBot.Repositories.Realizations
{
    public class KeyboardsFor : IKeyboards
    {
        public InlineKeyboardButton[][] CreateKeyboardChangeStop(UserPeriod userPeriod)
        {
            var buttons=new List<InlineKeyboardButton[]>{
                new[] { InlineKeyboardButton.WithCallbackData("Изменить", $"change_{userPeriod.Id}"),
                            InlineKeyboardButton.WithCallbackData("Остановить", $"stop_{userPeriod.Id}"),}
            };
            return buttons.ToArray();
        }

        public InlineKeyboardButton[][] CreateKeyboardPay(int idPeriod)
        {
            var buttons = new List<InlineKeyboardButton[]>{
                new[] { InlineKeyboardButton.WithCallbackData("Оплатить", $"money_{idPeriod}") }
            };
            return buttons.ToArray();
        }

        public InlineKeyboardButton[][] CreateKeyboardPeriods(List<Period> periods)
        {
            var buttons = new List<InlineKeyboardButton[]>();
            foreach (var ser in periods)
            {
                buttons.Add(new[] { InlineKeyboardButton.WithCallbackData($"{ser.Detail} за {ser.Price} рублей", $"period_{ser.PeriodId}") });
            }
            return buttons.ToArray();
        }

        public InlineKeyboardButton[][] CreateKeyboardRestart(UserPeriod userPeriod)
        {
            var buttons = new List<InlineKeyboardButton[]>{
                new[] {InlineKeyboardButton.WithCallbackData("Возобновить", $"change_{userPeriod.Id}"),}
            };
            return buttons.ToArray();
        }

        public InlineKeyboardButton[][] CreateKeyboardServices(List<ServiceSubs> serviceSubs)
        {
            var buttons = new List<InlineKeyboardButton[]>();
            foreach (var ser in serviceSubs)
            {
                buttons.Add(new[] { InlineKeyboardButton.WithCallbackData(ser.ServiceName, $"service_{ser.ServiceSubsId}") });
            }
            return buttons.ToArray();
        }

        public InlineKeyboardButton[][] CreateKeyboardServicesNew(int idServices)
        {
            var buttons = new List<InlineKeyboardButton[]>{
                new[]{ InlineKeyboardButton.WithCallbackData("Перейти к выбору подписки", $"service_{idServices}"),}

            };
            return buttons.ToArray();
        }
    }
}
