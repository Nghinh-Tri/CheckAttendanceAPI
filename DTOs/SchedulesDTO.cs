using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.DTOs
{
    public class SchedulesReadDTO
    {
        public int Id { get; set; }
        public int Class { get; set; }
        [MaxLength(8)]
        public string Student { get; set; }
        public int Attendance { get; set; }
    }
    public class SchedulesWriteDTO
    {
        public int Id { get; set; }
        public int Class { get; set; }
        [MaxLength(8)]
        public string Student { get; set; }
        public int Attendance { get; set; }
    }
}