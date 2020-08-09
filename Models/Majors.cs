using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Majors
    {
        [Key]
        [MaxLength(5)]
        public string MajorId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Translation { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
        public string DateCreate { get; set; }
    }
}