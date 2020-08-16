using System.Collections.Generic;
using System.Linq;

using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Repositories;

namespace CheckAttendanceAPI.Service
{
    public class RoomsService : BaseService, IRoomsRepository
    {
        public RoomsService(Context context) : base(context) {}

        public void Delete(Rooms rooms)
        {
            context.Rooms.Remove(rooms);
        }

        public List<Rooms> GetAll()
        {
            return context.Rooms.ToList();
        }

        public Rooms GetById(int id)
        {
            return context.Rooms.FirstOrDefault(p => p.Room == id);
        }

        public void Insert(Rooms rooms)
        {
            context.Rooms.Add(rooms);
        }
    }
}