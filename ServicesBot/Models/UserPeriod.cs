namespace ServicesBot.Models
{
    public class UserPeriod
    {
        public int Id { get; set; }
        public long MyUser { get; set; }

        public int PeriodId { get; set; }
        public Period Period { get; set; } = null!;

        public int StatusId { get; set; }
        public Status Status { get; set; } = null!;

        public DateOnly StartDay { get; set; }
        public DateOnly EndDay { get; set; }

    }
}
