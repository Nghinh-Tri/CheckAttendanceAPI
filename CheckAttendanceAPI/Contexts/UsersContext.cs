using Microsoft.EntityFrameworkCore;
using CheckAttendanceAPI.Models;

namespace CheckAttendanceAPI.Contexts
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> opt): base(opt){}

        public DbSet<Users> Users { get; set; }
    }
}