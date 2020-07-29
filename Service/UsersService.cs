using System.Collections.Generic;
using System.Linq;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;

namespace CheckAttendanceAPI.Service
{
    public class UsersService : IUsersRepository
    {
        private readonly Context context;
        public UsersService(Context context){this.context = context;}
        public IEnumerable<Users> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public Users GetUserById(string id)
        {
            return context.Users.FirstOrDefault(p => p.UserId == id);
        }
    }
}