using System.Linq;

using System.Collections.Generic;
using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;

namespace CheckAttendanceAPI.Service
{
    public class SubjectsService : BaseService, ISubjectsRepository
    {
        public SubjectsService(Context context) : base(context) { }

        public void Delete(Subjects subjects)
        {
            context.Subjects.Remove(subjects);
        }

        public List<Subjects> GetAll()
        {
            return context.Subjects.ToList();
        }

        public Subjects GetById(string id)
        {
            return context.Subjects.FirstOrDefault(p => p.SubjectId == id);
        }

        public void Insert(Subjects subjects)
        {
            context.Subjects.Add(subjects);
        }

        public void Update(Subjects subjects) { }
    }
}