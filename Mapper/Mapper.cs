using AutoMapper;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace CheckAttendanceAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<AdministratorsDTO, Administrators>();
            CreateMap<AdministratorsStatusDTO, Administrators>();

            CreateMap<UserCreatorDTO, Users>();
            CreateMap<UserUpdateDTO, Users>();
            CreateMap<Users, UserGetDTO>();

            CreateMap<SlotInsertDTO, Slots>();
            CreateMap<SlotUpdateDTO, Slots>();
            CreateMap<Slots, SlotDTO>();

            CreateMap<RoomsDTO, Rooms>();
            CreateMap<Rooms, RoomsDTO>();

            CreateMap<MajorsCreateDTO, Majors>();
            CreateMap<Majors, MajorsReadDTO>();
            CreateMap<MajorsUpdateDTO, Majors>();

            CreateMap<StudentsCreateDTO, Students>();
            CreateMap<Students, StudentsReadDTO>();

            CreateMap<LecturersDTO, Lecturers>();
            CreateMap<Lecturers, LecturersDTO>();
        }
    }
}