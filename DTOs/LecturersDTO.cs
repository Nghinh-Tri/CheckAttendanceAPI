using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.DTOs
{
    public class LecturersDTO
    {
        [MaxLength(8)]
        public string UserId { get; set; }
        [MaxLength(5)]
        public string Major { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
    }
}
