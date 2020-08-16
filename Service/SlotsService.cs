using System.Collections.Generic;
using System;
using System.Linq;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Data;

namespace CheckAttendanceAPI.Service
{
    public class SlotsService : BaseService, ISlotsRepository
    {
        public SlotsService(Context context) : base(context) { }

        //Get All
        List<Slots> ISlotsRepository.GetAll()
        {
            return context.Slots.ToList();
        }

        //Get By Id
        public Slots GetById(int id)
        {
            return context.Slots.FirstOrDefault(r => r.Slot == (int)id);
        }

        //Delete
        public void Delete(Slots slot)
        {
            context.Slots.Remove((Slots)slot);
        }

        //Insert
        void ISlotsRepository.Insert(Slots slot)
        {
            context.Slots.Add(slot);
        }

        //Update
        public void Update(Slots slot) { }
    }
}