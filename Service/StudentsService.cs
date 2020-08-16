using System.Collections.Generic;
using System.Linq;

using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;

namespace CheckAttendanceAPI.Service
{
    public class StudentsService : BaseService, IStudentsRepository
    {
        public StudentsService(Context context) : base(context) { }

        public void Delete(Students students)
        {
            context.Students.Remove(students);
        }

        public List<Students> GetAll()
        {
            return context.Students.ToList();
        }

        public Students GetById(string id)
        {
            return context.Students.FirstOrDefault(p => p.UserId == id);
        }

        public void Insert(Students students)
        {
            context.Students.Add(students);
        }

        public void Update(Students students) { }
    }
}