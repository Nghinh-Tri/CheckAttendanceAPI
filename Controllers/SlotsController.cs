using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using AutoMapper;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace Controllers
{
    [Authorize]
    [Route("api/slots")]
    public class SlotsController : ControllerBase
    {
        private readonly ISlotsRepository repository;
        private readonly IMapper mapper;
        public SlotsController(ISlotsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        //Get All
        [HttpGet]
        public ActionResult<Dictionary<string, IEnumerable<Slots>>> GetAllSlot(){
            try
            {
                var slots = repository.GetAll();
                Dictionary<string, IEnumerable<Slots>> result = new Dictionary<string, IEnumerable<Slots>>();
                result.Add("Slots", slots);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get All
        [HttpGet("{id}")]
        public ActionResult<SlotDTO> GetSlotById(string id){
            try
            {
                var slots =  repository.GetById(Int32.Parse(id));                
                return Ok(mapper.Map<SlotDTO>(slots));
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //insert
        [HttpPost]
        public IActionResult Insert([FromBody] SlotInsertDTO dto){
            try
            {
                var model = mapper.Map<Slots>(dto);
                if (model != null){
                    repository.Insert(model);
                    var result = repository.SaveChanges();
                    if (result)
                        return Ok();
                }
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Update
        [HttpPut("{id}")]
        public IActionResult Update(string id, [FromBody] SlotUpdateDTO dto){
            try
            {
                var isExist = repository.GetById(Int32.Parse(id));
                if (isExist != null){
                    mapper.Map(dto, isExist);
                    repository.Update(isExist);
                    var result = repository.SaveChanges();
                    if (result)
                        return Ok();
                }
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }
    }
}