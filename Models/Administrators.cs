using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Administrators
    {
        [Key]
        [MaxLength(8)]
        public string UserId { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}