using Microsoft.EntityFrameworkCore;
using CheckAttendanceAPI.Models;

namespace CheckAttendanceAPI.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt) : base(opt) { }
        public DbSet<Administrators> Administrators { get; set; }
        public DbSet<Certifications> Certifications { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Lecturers> Lecturers { get; set; }
        public DbSet<Majors> Majors { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<Slots> Slots { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}