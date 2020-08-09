using AutoMapper;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs.Users;
using CheckAttendanceAPI.DTOs.Adminstrators;

namespace CheckAttendanceAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AdministratorsDTO,Administrators>();
            CreateMap<UserCreatorDTO,Users>();
            CreateMap<UserUpdateDTO,Users>();
        }
    }
}