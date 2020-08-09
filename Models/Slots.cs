using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Slots
    {
        [Key]
        public int Slot { get; set; }
        [MaxLength(10)]
        public string BeginTime { get; set; }
        [MaxLength(10)]
        public string EndTIme { get; set; }
    }
}