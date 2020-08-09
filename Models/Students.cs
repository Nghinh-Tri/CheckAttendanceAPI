using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Students
    {
        [Key]
        [MaxLength(8)]
        public string UserId { get; set; }
        [MaxLength(5)]
        public string Major { get; set; }
        [MaxLength(10)]
        public string Course { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
    }
}