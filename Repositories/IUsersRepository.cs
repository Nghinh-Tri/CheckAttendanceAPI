using System.Collections.Generic;
using CheckAttendanceAPI.Models;

namespace CheckAttendanceAPI.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUsers();

        Users GetUserById(string id);

        void CreateUser(Users users);

        void DeleteUser(Users user);
        
        void UpdateUser(Users user);

        bool SaveChanges();
    }
}