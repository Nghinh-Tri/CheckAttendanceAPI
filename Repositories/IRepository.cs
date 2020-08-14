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

        void Delete(Users users);

        void Update(Users users);

        void Insert(Users users);

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
        void Insert(Slots slots);
        Slots GetById(int id);

        void Delete(Slots slots);

        void Update(Slots slots);

        bool SaveChanges();
    }

    public interface IRoomsRepository
    {
        List<Rooms> GetAll();
        void Insert(Rooms rooms);
        Rooms GetById(int id);
        void Delete(Rooms rooms);
        bool SaveChanges();
    }

    public interface IMajorsRepository
    {
        List<Majors> GetAll();
        void Insert(Majors majors);
        void Update(Majors majors);
        Majors GetById(string id);
        void Delete(Majors rooms);
        bool SaveChanges();
    }
}