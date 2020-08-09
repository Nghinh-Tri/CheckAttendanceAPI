using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.DTOs.Adminstrators
{
    public class AdministratorsDTO
    {
        [MaxLength(8)]
        public string UserId { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}