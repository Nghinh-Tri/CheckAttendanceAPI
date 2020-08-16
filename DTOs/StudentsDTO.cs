using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.DTOs
{
    public class StudentsCreateDTO
    {
        [MaxLength(8)]
        public string UserId { get; set; }
        [MaxLength(5)]
        public string Major { get; set; }
        [MaxLength(10)]
        public string Course { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
    }
    public class StudentsReadDTO
    {
        [MaxLength(8)]
        public string UserId { get; set; }
        [MaxLength(5)]
        public string Major { get; set; }
        [MaxLength(10)]
        public string Course { get; set; }
    }
}