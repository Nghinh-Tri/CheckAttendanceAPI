using System.ComponentModel.DataAnnotations;
using System;

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
        public bool Status { get; set; }
        public DateTime DateCreate { get; set; }
    }
}