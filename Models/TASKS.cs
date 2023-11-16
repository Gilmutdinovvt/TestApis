using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication7.Models
{
    public class TASKS
    {
        [Key]
        public Guid Guid { get; set; }
        public DateTime? DateTime { get; set; }
        public string Status { get; set; }
    }
}
