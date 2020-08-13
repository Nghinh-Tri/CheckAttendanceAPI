using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.DTOs
{
    public class SlotDTO
    {
        public int Slot { get; set; }
        public string BeginTime { get; set; }
        public string EndTIme { get; set; }
    }

    public class SlotInsertDTO
    {
        public int Slot { get; set; }
        [MaxLength(10)]
        public string BeginTime { get; set; }
        [MaxLength(10)]
        public string EndTIme { get; set; }
    }

    public class SlotUpdateDTO
    {
        [MaxLength(10)]
        public string BeginTime { get; set; }
        [MaxLength(10)]
        public string EndTIme { get; set; }
    }
}
