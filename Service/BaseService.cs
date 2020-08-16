using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;

namespace CheckAttendanceAPI.Service
{
    public class BaseService : IRepository
    {
        protected readonly Context context;
        public BaseService(Context context) => this.context = context;
        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }
    }
}