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

        public void Create(object obj)
        {
            var users = (Users) obj;
            if (users == null)
            {
                throw new ArgumentException(nameof(users));
            }
            context.Users.Add(users);
        }

        public void Delete(object obj)
        {
            context.Users.Remove((Users)obj);
        }

        public object GetById(object id)
        {
            return context.Users.FirstOrDefault(p => p.UserId == (string)id);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }

        public void Update(object obj){}

        IEnumerable<object> IRepository.GetAll()
        {
            return context.Users.ToList();
        }
    }
}