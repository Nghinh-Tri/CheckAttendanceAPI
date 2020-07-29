using Microsoft.EntityFrameworkCore;
using CheckAttendanceAPI.Models;

namespace CheckAttendanceAPI.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opt): base(opt){}

        public DbSet<Users> Users { get; set; }
    }
}