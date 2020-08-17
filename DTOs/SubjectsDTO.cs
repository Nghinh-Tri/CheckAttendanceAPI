using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.DTOs
{
    public class SubjectsDTO
    {
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
    }
}