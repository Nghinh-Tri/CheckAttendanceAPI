using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.Models
{
    public class Rooms
    {
        [Key]
        public int Room { get; set; }
    }
}