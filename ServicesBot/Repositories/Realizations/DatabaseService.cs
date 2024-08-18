using Microsoft.EntityFrameworkCore;
using ServicesBot.Models;
using Telegram.Bot.Types;

namespace ServicesBot.Repositories.Realizations
{
    public class DatabaseService : IDataBaseOptions
    {
        public Period GetPeriod(ServicesSubsContext context, int idPeriod)
        {
             return context.Periods.First(z => z.PeriodId == idPeriod);
        }

        public List<Period> GetPeriods(ServicesSubsContext context, int serviceid)
        {
            return context.Periods.Where(z => z.ServiceSubsId == serviceid).ToList();
        }

        public List<ServiceSubs> GetServiceSubs(ServicesSubsContext context)
        {
            List<ServiceSubs> serviceSubs = context.Services.ToList();
            return serviceSubs;
        }

        public UserPeriod GetUserPeriod(ServicesSubsContext context, long userId, int serviceSubs)
        {
            return context.UserPeriods.Include(x => x.Period).ThenInclude(c => c.ServiceSubs).Include(s => s.Status).FirstOrDefault(p => p.MyUser == userId && p.Period.ServiceSubsId == serviceSubs);
        }

        public UserPeriod GetUserPeriodById(ServicesSubsContext context, int id)
        {
            return context.UserPeriods.Include(z => z.Period).FirstOrDefault(z => z.Id == id);
        }

        public UserPeriod GetUserPeriodByPeriod(ServicesSubsContext context, int periodId, long userId)
        {
            return context.UserPeriods.FirstOrDefault(p => p.MyUser == userId && p.PeriodId == periodId);
        }

        public List<UserPeriod> GetUserPeriods(ServicesSubsContext context, long userId)
        {
            return context.UserPeriods.Include(x => x.Period).ThenInclude(c => c.ServiceSubs).Include(s => s.Status).Where(z => z.MyUser == userId).ToList();
        }
    }
}
