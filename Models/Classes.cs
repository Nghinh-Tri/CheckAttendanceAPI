using System.ComponentModel.DataAnnotations;
using System;

namespace CheckAttendanceAPI.Models
{
    public class Classes
    {
        [Key]
        public int Id { get; set; }
        public int Slot { get; set; }
        public int Room { get; set; }
        [MaxLength(10)]
        public string Subject { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(8)]
        public string Lecturer { get; set; }
        [MaxLength(10)]
        public string Status { get; set; }
    }
}