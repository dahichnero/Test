
using ServicesBot.Models;

namespace ServicesBot.Repositories.Realizations
{
    public class DateEx : IDateExamples
    {
        public int DateMinus(DateOnly ends)//будет использоваться userPeriod.EndDay
        {
            DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Today);
            TimeSpan difference = ends.ToDateTime(TimeOnly.MinValue) - dateOnly.ToDateTime(TimeOnly.MinValue);
            return difference.Days;
        }
    }
}
