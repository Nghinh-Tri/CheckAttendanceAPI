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
    public interface ICertificationsRepository : IRepository
    {
        List<Certifications> GetAll();
        void Insert(Certifications certifications);
        void Update(Certifications certifications);
        Certifications GetById(string userId);
        void Delete(Certifications certifications);
    }
    public interface IClassesRepository : IRepository
    {
        List<Classes> GetAll();
        void Insert(Classes certifications);
        void Update(Classes certifications);
        Classes GetById(int id);
        void Delete(Classes certifications);
    }
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
    public interface ISchedulesRepository : IRepository {
        List<Schedules> GetAll();
        void Insert(Schedules schedules);
        void Update(Schedules schedules);
        Schedules GetById(int id);
        void Delete(Schedules schedules);
     }
    public interface ISlotsRepository : IRepository
    {
        List<Slots> GetAll();
        void Insert(Slots slots);
        Slots GetById(int id);

        void Delete(Slots slots);

        void Update(Slots slots);
    }
    public interface IStudentsRepository : IRepository
    {
        List<Students> GetAll();
        void Insert(Students students);
        void Update(Students students);
        Students GetById(string id);
        void Delete(Students students);
    }
    public interface ISubjectsRepository : IRepository { 
        List<Subjects> GetAll();
        void Insert(Subjects subjects);
        void Update(Subjects subjects);
        Subjects GetById(string id);
        void Delete(Subjects subjects);
    }
    public interface IUsersRepository : IRepository
    {
        List<Users> GetAll();
        Users GetById(string id);

        void Delete(Users users);

        void Update(Users users);

        void Insert(Users users);
    }
}