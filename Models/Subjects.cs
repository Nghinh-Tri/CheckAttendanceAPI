using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Subjects
    {
        [Key]
        [MaxLength(10)]
        public string SubjectId { get; set; }
        [MaxLength(5)]
        public string Major { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Translation { get; set; }
        public int Certification { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
        public string DateCreate { get; set; }
    }
}