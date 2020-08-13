namespace CheckAttendanceAPI.DTOs
{
    public class UserCreatorDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }

    }

    public class UserGetDTO
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Dob { get; set; }
        public string IdentityCard { get; set; }
        public string Phone { get; set; }
        public string Sex { get; set; }
        public string Role { get; set; }
        public string DateCreate { get; set; }
        public string Image { get; set; }
    }

    public class UserUpdateDTO
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}