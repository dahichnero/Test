using ServicesBot.Models;

namespace ServicesBot.Repositories
{
    public interface IMessages
    {
        string InfoAbout(UserPeriod userPeriod);

        string ServiceStop();
        string ChoosePeriod();
        string WellDonePay();
        string WellDonePayed();
        string ChooseChangeService();
        string NewServices();
        string CheckNewServices();
        string OhSorry();
        string LetsStart();
        string Hello();
    }
}
