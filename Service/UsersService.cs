using System.Collections.Generic;
using System.Linq;
using System;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;

namespace CheckAttendanceAPI.Service
{
    public class UsersService : BaseService, IUsersRepository
    {
        public UsersService(Context context) : base(context) { }

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