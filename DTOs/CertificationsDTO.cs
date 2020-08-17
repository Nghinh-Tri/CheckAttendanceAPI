using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.DTOs
{
    public class CertificationsDTO
    {
        public string Student { get; set; }
        public int Schedule { get; set; }
        public float Grade { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
    }
}