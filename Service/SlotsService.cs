using System.Collections.Generic;
using System;
using System.Linq;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Contexts;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.Data;

namespace CheckAttendanceAPI.Service
{
    public class SlotsService : ISlotsRepository
    {
        private readonly Context context;
        public SlotsService(Context context)
        {
            this.context = context;
        }

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

        //Save change
        public bool SaveChanges()
        {
            return context.SaveChanges() >= 0;
        }

        //Update
        public void Update(Slots slot) { }
    }
}