using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Certifications
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(8)]
        public Students Student { get; set; }
        public int Schedule { get; set; }
        public float Grade { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
        public string DateUpdate { get; set; }
    }
}