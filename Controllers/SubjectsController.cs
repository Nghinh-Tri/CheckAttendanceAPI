using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System;
using System.Collections.Generic;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.DTOs;
using CheckAttendanceAPI.Models;

namespace Controllers
{
    [Authorize]
    [Route("api/subjects")]
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectsRepository repository;
        private readonly IMapper mapper;
        public SubjectsController(ISubjectsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //Get All
        [HttpGet]
        public ActionResult<Dictionary<string, IEnumerable<Subjects>>> GetAllSubjects()
        {
            try
            {
                var list = repository.GetAll();
                Dictionary<string, IEnumerable<Subjects>> result = new Dictionary<string, IEnumerable<Subjects>>();
                result.Add("Subjects", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get By id
        [HttpGet("{id}")]
        public ActionResult<SubjectsDTO> GetSubjectsById(string id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result != null)
                    return Ok(mapper.Map<SubjectsDTO>(result));
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }
        //insert
        [HttpPost]
        public IActionResult Insert([FromBody] SubjectsDTO dto)
        {
            try
            {
                var model = mapper.Map<Subjects>(dto);
                if (model != null)
                {
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
        public IActionResult Update(string id, [FromBody] SubjectsDTO dto)
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