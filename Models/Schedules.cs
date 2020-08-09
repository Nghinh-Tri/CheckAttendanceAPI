using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Schedules
    {
        [Key]
        public int Id { get; set; }
        public int Class { get; set; }
        [MaxLength(8)]
        public string Student { get; set; }
        public int Attendance { get; set; }
    }
}