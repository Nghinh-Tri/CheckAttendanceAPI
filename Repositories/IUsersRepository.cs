using System.Collections.Generic;
using CheckAttendanceAPI.Models;

namespace CheckAttendanceAPI.Repositories
{
    public interface IUsersRepository
    {
        IEnumerable<Users> GetAllUsers();
    }
}