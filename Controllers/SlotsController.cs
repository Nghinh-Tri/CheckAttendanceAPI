using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using AutoMapper;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace Controllers
{
    // [Authorize]
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
                var list = repository.GetAll();
                Dictionary<string, IEnumerable<Slots>> result = new Dictionary<string, IEnumerable<Slots>>();
                result.Add("Slots", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get All
        [HttpGet("{id}")]
        public ActionResult<SlotDTO> GetSlotById(int id){
            try
            {
                var slots =  repository.GetById(id);         
                if (slots != null)       
                    return Ok(mapper.Map<SlotDTO>(slots));
                return NotFound();
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
        public IActionResult Update(int id, [FromBody] SlotUpdateDTO dto){
            try
            {
                var isExist = repository.GetById(id);
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