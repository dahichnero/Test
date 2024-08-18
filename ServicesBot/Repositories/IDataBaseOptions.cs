using ServicesBot.Models;

namespace ServicesBot.Repositories
{
    public interface IDataBaseOptions
    {
        List<ServiceSubs> GetServiceSubs(ServicesSubsContext context);
        List<UserPeriod> GetUserPeriods(ServicesSubsContext context, long userId);

        List<Period> GetPeriods(ServicesSubsContext context, int serviceid);

        UserPeriod GetUserPeriod(ServicesSubsContext context, long userId, int serviceSubs);

        Period GetPeriod(ServicesSubsContext context, int idPeriod);

        UserPeriod GetUserPeriodById(ServicesSubsContext context, int id);

        UserPeriod GetUserPeriodByPeriod(ServicesSubsContext context, int periodId, long userId);
    }
}
