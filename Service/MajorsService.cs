using System.Collections.Generic;
using System.Linq;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;

namespace CheckAttendanceAPI.Service
{
    public class MajorsService : IMajorsRepository
    {
        private readonly Context context;
        public MajorsService(Context context) { this.context = context; }
        public void Delete(Majors rooms)
        {
            context.Majors.Remove(rooms);
        }

        public List<Majors> GetAll()
        {
            return context.Majors.ToList();
        }

        public Majors GetById(string id)
        {
            return context.Majors.FirstOrDefault(p => p.MajorId == id);
        }

        public void Insert(Majors majors)
        {
            context.Majors.Add(majors);
        }

        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }

        public void Update(Majors majors) { }
    }
}