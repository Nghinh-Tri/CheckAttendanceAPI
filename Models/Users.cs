using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Users
    {
        [Key]
        [MaxLength(30)]
        public string UserId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
    }
}