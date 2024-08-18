using System.ComponentModel.DataAnnotations;

namespace ServicesBot.Models
{
    public class ServiceSubs
    {
        public int ServiceSubsId { get; set; }

        [StringLength(100)]
        public string ServiceName { get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;
    }
}
