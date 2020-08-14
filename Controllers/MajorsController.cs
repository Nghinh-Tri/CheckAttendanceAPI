using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Authorization;
using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.Models;
using CheckAttendanceAPI.DTOs;

namespace Controllers
{
    // [Authorize]
    [Route("api/majors")]
    public class MajorsController : ControllerBase
    {
        private readonly IMajorsRepository repository;
        private readonly IMapper mapper;

        public MajorsController(IMajorsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        //Get All
        [HttpGet]
        public ActionResult<Dictionary<string, List<Majors>>> GetAll()
        {
            try
            {
                var list = repository.GetAll();
                Dictionary<string, List<Majors>> result = new Dictionary<string, List<Majors>>();
                result.Add("Majors", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get By Id
        [HttpGet("{id}")]
        public ActionResult<MajorsReadDTO> GetById(string id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result != null)
                    return Ok(mapper.Map<MajorsReadDTO>(result));
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Insert
        [HttpPost]
        public IActionResult Insert([FromBody] MajorsCreateDTO dto)
        {
            try
            {
                var model = mapper.Map<Majors>(dto);
                if (model != null)
                {
                    model.Status = true;
                    model.DateCreate = DateTime.Now;
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
        public IActionResult Update(string id, [FromBody] MajorsUpdateDTO dto)
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