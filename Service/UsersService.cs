using System.Collections.Generic;
using System.Linq;
using System;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;

namespace CheckAttendanceAPI.Service
{
    public class UsersService : IUsersRepository
    {
        private readonly Context context;
        public UsersService(Context context) { this.context = context; }

        public void CreateUser(Users users)
        {
            if (users == null)
            {
                throw new ArgumentException(nameof(users));
            }
            context.Users.Add(users);
        }

        public void DeleteUser(Users user)
        {
            context.Users.Remove(user);
        }

        public IEnumerable<Users> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public Users GetUserById(string id)
        {
            return context.Users.FirstOrDefault(p => p.UserId == id);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }
    }
}