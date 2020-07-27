using System.Collections.Generic;
using System.Linq;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;

namespace CheckAttendanceAPI.Service
{
    public class UsersService : IUsersRepository
    {
        private readonly UsersContext context;
        public UsersService(UsersContext context){this.context = context;}
        public IEnumerable<Users> GetAllUsers()
        {
            return context.Users.ToList();
        }
    }
}