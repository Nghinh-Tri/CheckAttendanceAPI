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

        //Get All
        List<Users> IUsersRepository.GetAll()
        {
            return context.Users.ToList();
        }

        //Get By Id
        public Users GetById(string id)
        {
            return context.Users.FirstOrDefault(p => p.UserId == id);
        }

        //Save Change
        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }

        //Insert
        public void Insert(Users user)
        {
            context.Users.Add(user);
        }

        //Delete
        public void Delete(Users user)
        {
            context.Users.Remove(user);
        }

        //Update  
        public void Update(Users user) { }


    }
}