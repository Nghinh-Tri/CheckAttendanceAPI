using System.Collections.Generic;
using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;

namespace CheckAttendanceAPI.Service
{
    public class ClassesService : BaseService, IClassesRepository
    {
        public ClassesService(Context context) : base(context) { }

        public void Delete(Classes certifications)
        {
        }

        public List<Classes> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Classes GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Classes certifications)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Classes certifications)
        {
            throw new System.NotImplementedException();
        }
    }
}