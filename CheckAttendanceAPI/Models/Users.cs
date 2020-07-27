using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Users
    {
        [Key]
        [MaxLength(30)]
        public string UserId { get; set; }
        [MaxLength(30)]
        public string Passwords { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
    }
}