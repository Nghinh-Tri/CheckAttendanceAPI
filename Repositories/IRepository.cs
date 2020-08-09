using System.Collections.Generic;

namespace CheckAttendanceAPI.Repositories
{
    public interface IRepository
    {
        IEnumerable<object> GetAll();

        object GetById(object id);

        void Create(object obj){}

        void Delete(object obj);
        
        void Update(object obj);

        bool SaveChanges();
    }
}