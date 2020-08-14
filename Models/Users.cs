using System.ComponentModel.DataAnnotations;
using System;

namespace CheckAttendanceAPI.Models
{
    public class Users
    {
        [Key]
        [MaxLength(8)]
        public string UserId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        public string Dob { get; set; }
        [MaxLength(12)]
        public string IdentityCard { get; set; }
        [MaxLength(10)]
        public string Phone { get; set; }
        [MaxLength(10)]
        public string Sex { get; set; }
        [MaxLength(10)]
        public string Role { get; set; }
        public DateTime DateCreate { get; set; }
        public string Image { get; set; }
    }
}