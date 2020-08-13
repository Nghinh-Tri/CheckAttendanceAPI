using System.Collections.Generic;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Data;
using System;

namespace CheckAttendanceAPI.Repositories
{
    public interface IUsersRepository
    {
        List<Users> GetAll();
        Users GetById(string id);

        void Delete(Users obj);

        void Update(Users obj);

        void Insert(Users obj);

        bool SaveChanges();
    }

    public interface IAuthentication
    {
        string Authenticate(Administrators administrators);
        void Insert(Administrators administrators);
        void Update(Administrators administrators);
        bool SaveChanges();
        Administrators GetById(string id);
    }

    public interface ISlotsRepository
    {
        List<Slots> GetAll();
        void Insert(Slots slots) { }
        Slots GetById(int id);

        void Delete(Slots obj);

        void Update(Slots obj);

        bool SaveChanges();
    }
}