using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ServicesBot.Models
{
    public class Status
    {
        public int StatusId { get; set; }

        [StringLength(50)]
        public string StatusName { get; set; } = string.Empty;
    }
}
