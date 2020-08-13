using System.ComponentModel.DataAnnotations;

namespace CheckAttendanceAPI.DTOs
{
    public class AdministratorsDTO
    {
        [MaxLength(8)]
        public string UserId { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }

    public class AdministratorsStatusDTO
    {
        public bool Status { get; set; }
    }
}