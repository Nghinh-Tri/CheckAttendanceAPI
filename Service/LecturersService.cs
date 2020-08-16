using System.Linq;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;
using System.Collections.Generic;
using CheckAttendanceAPI.Contexts;

namespace CheckAttendanceAPI.Service
{
    public class LecturersService : BaseService, ILecturersRepository
    {
        public LecturersService(Context context) : base(context) { }

        public void Delete(Lecturers lecturers)
        {
            context.Lecturers.Remove(lecturers);
        }

        public List<Lecturers> GetAll()
        {
            return context.Lecturers.ToList();
        }

        public Lecturers GetById(string id)
        {
            return context.Lecturers.FirstOrDefault(p => p.UserId == id);
        }

        public void Insert(Lecturers lecturers)
        {
            context.Lecturers.Add(lecturers);
        }

        public void Update(Lecturers lecturers) { }
    }
}