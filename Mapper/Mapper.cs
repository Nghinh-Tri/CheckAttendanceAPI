using AutoMapper;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UserCreatorDTO,Users>();
        }
    }
}