using AutoMapper;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace CheckAttendanceAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AdministratorsDTO,Administrators>();
            CreateMap<AdministratorsStatusDTO,Administrators>();
            CreateMap<UserCreatorDTO,Users>();
            CreateMap<UserUpdateDTO,Users>();
            CreateMap<Users,UserGetDTO>();
            CreateMap<SlotInsertDTO,Slots>();
            CreateMap<SlotUpdateDTO,Slots>();
            CreateMap<Slots,SlotDTO>();
        }
    }
}