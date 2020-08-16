using System.Collections.Generic;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Data;
using System;

namespace CheckAttendanceAPI.Repositories
{
    public interface IRepository
    {
        bool SaveChanges();
    }
    public interface IAuthentication : IRepository
    {
        string Authenticate(Administrators administrators);
        void Insert(Administrators administrators);
        void Update(Administrators administrators);
        Administrators GetById(string id);
    }
    public interface ICertificationsRepository : IRepository { }
    public interface IClassesRepository : IRepository { }
    public interface ILecturersRepository : IRepository
    {
        List<Lecturers> GetAll();
        void Insert(Lecturers lecturers);
        void Update(Lecturers lecturers);
        Lecturers GetById(string id);
        void Delete(Lecturers lecturers);
    }
    public interface IMajorsRepository : IRepository
    {
        List<Majors> GetAll();
        void Insert(Majors majors);
        void Update(Majors majors);
        Majors GetById(string id);
        void Delete(Majors majors);
    }
    public interface IRoomsRepository : IRepository
    {
        List<Rooms> GetAll();
        void Insert(Rooms rooms);
        Rooms GetById(int id);
        void Delete(Rooms rooms);
    }
    public interface ISchedulesRepository: IRepository { }
    public interface ISlotsRepository : IRepository
    {
        List<Slots> GetAll();
        void Insert(Slots slots);
        Slots GetById(int id);

        void Delete(Slots slots);

        void Update(Slots slots);
    }
    public interface IStudentsRepository: IRepository
    {
        List<Students> GetAll();
        void Insert(Students students);
        void Update(Students students);
        Students GetById(string id);
        void Delete(Students students);
    }
    public interface ISubjectsRepository: IRepository { }
    public interface IUsersRepository: IRepository
    {
        List<Users> GetAll();
        Users GetById(string id);

        void Delete(Users users);

        void Update(Users users);

        void Insert(Users users);
    }
}