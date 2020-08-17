using System.Linq;

using System.Collections.Generic;
using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Repositories;

namespace CheckAttendanceAPI.Service
{
    public class SchedulesService : BaseService, ISchedulesRepository
    {
        public SchedulesService(Context context) : base(context) { }

        public void Delete(Schedules schedules)
        {
            context.Schedules.Remove(schedules);
        }

        public List<Schedules> GetAll()
        {
            return context.Schedules.ToList();
        }

        public Schedules GetById(int id)
        {
            return context.Schedules.FirstOrDefault(p => p.Id == id);
        }

        public void Insert(Schedules schedules)
        {
            context.Schedules.Add(schedules);
        }

        public void Update(Schedules schedules) { }
    }
}