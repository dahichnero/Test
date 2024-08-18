using ServicesBot.Models;

namespace ServicesBot.Repositories.Realizations
{
    public class AllMessages : IMessages
    {
        public string CheckNewServices()
        {
            return "Можете выбрать сервис, который вам по душе";
        }

        public string ChooseChangeService()
        {
            return "Вы хотите что-то сделать с вашей подпиской?";
        }

        public string ChoosePeriod()
        {
            return "Выберите любой период за определенную цену";
        }

        public string Hello()
        {
            return "Добро пожаловать в бот управления подписками! Рады тебя видеть здесь. Если ты здесь впервые, то советую ознакомиться с командой\n /menu.";
        }

        public string InfoAbout(UserPeriod userPeriod)
        {
            DateEx dateEx = new DateEx();
            int difference = dateEx.DateMinus(userPeriod.EndDay);
            return $"{userPeriod.Period.ServiceSubs.ServiceName} Статус: {userPeriod.Status.StatusName} Осталось дней: {difference} Ссылка на бота: https://telegrambot.fake\n";
        }

        public string LetsStart()
        {
            return "Раз уж вы разобрались с работой команд, то советую Выбрать 1 из двух команд: Сервисы или Личный кабинет.";
        }

        public string NewServices()
        {
            return "Новые серсивы, которые вам доступны для оформления.";
        }

        public string OhSorry()
        {
            return "К сожалению, у вас не оформлено ни одной подписки, обратитесь в раздел Сервисы в главном меню.";
        }

        public string ServiceStop()
        {
            return "Данная подписка остановлена. Может хотите её возобновить? Перейдите на главное меню и выберите необходимый вам сервис.";
        }

        public string WellDonePay()
        {
            return "Отлично, теперь оплатите данную покупку";
        }

        public string WellDonePayed()
        {
            return "Отлично, вы оплатили сервис. Если вас что-то беспкоит по поводу подписки, то можете выбрать из ниже представленных функций";
        }
    }
}
