using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.DTOs;
using CheckAttendanceAPI.Models;

namespace Controllers
{
    [Authorize]
    [Route("api/schedules")]
    public class SchedulesController : ControllerBase
    {
        private readonly ISchedulesRepository repository;
        private readonly IMapper mapper;
        public SchedulesController(ISchedulesRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //Get All
        [HttpGet]
        public ActionResult<Dictionary<string, IEnumerable<Schedules>>> GetAllSchedules()
        {
            try
            {
                var list = repository.GetAll();
                Dictionary<string, IEnumerable<Schedules>> result = new Dictionary<string, IEnumerable<Schedules>>();
                result.Add("Schedules", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get By id
        [HttpGet("{id}")]
        public ActionResult<SchedulesReadDTO> GetSchedulesById(int id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result != null)
                    return Ok(mapper.Map<SchedulesReadDTO>(result));
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }
        //insert
        [HttpPost]
        public IActionResult Insert([FromBody] SchedulesWriteDTO dto)
        {
            try
            {
                var model = mapper.Map<Schedules>(dto);
                if (model != null)
                {
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
        public IActionResult Update(int id, [FromBody] SchedulesWriteDTO dto)
        {
            try
            {
                var isExist = repository.GetById(id);
                if (isExist != null)
                {
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