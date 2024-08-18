using System.ComponentModel.DataAnnotations;

namespace ServicesBot.Models
{
    public class Period
    {
        public int PeriodId { get; set; }

        public double Price { get; set; }
        public int CountDays { get; set; }

        public int ServiceSubsId { get; set; }

        [StringLength(100)]
        public string Detail { get; set; } = string.Empty;

        public ServiceSubs ServiceSubs { get; set; } = null!;
    }
}
