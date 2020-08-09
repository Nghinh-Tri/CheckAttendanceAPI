using CheckAttendanceAPI.Models;

namespace CheckAttendanceAPI.Repositories
{
    public interface IAuthentication
    {
        public string Authenticate(Administrators administrators);
    }
}