using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.DTOs
{
    public class MajorsCreateDTO
    {
        [MaxLength(5)]
        public string MajorId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Translation { get; set; }
    }

    public class MajorsUpdateDTO
    {
        [MaxLength(50)]
        public string Title { get; set; }
        [MaxLength(50)]
        public string Translation { get; set; }
        public bool Status { get; set; }
    }

    public class MajorsReadDTO
    {
        [MaxLength(5)]
        public string MajorId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
    }
}