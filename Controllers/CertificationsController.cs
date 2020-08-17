using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using System.Collections.Generic;
using System;

using CheckAttendanceAPI.Repositories;
using CheckAttendanceAPI.DTOs;
using CheckAttendanceAPI.Models;

namespace Controllers
{
    [Authorize]
    [Route("api/certifications")]
    public class CertificationsController : ControllerBase
    {
        private readonly ICertificationsRepository repository;
        private readonly IMapper mapper;
        public CertificationsController(ICertificationsRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        //Get All
        [HttpGet]
        public ActionResult<Dictionary<string, IEnumerable<Certifications>>> GetAllCertifications()
        {
            try
            {
                var list = repository.GetAll();
                Dictionary<string, IEnumerable<Certifications>> result = new Dictionary<string, IEnumerable<Certifications>>();
                result.Add("Certifications", list);
                return Ok(result);
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }

        //Get By id
        [HttpGet("{id}")]
        public ActionResult<CertificationsDTO> GetCertificationsById(string id)
        {
            try
            {
                var result = repository.GetById(id);
                if (result != null)
                    return Ok(mapper.Map<CertificationsDTO>(result));
                return NotFound();
            }
            catch (System.Exception msg)
            {
                return NotFound(msg);
            }
        }
        //insert
        [HttpPost]
        public IActionResult Insert([FromBody] CertificationsDTO dto)
        {
            try
            {
                var model = mapper.Map<Certifications>(dto);
                if (model != null)
                {
                    model.DateUpdate = DateTime.Now;
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
        public IActionResult Update(string id, [FromBody] CertificationsDTO dto)
        {
            try
            {
                var isExist = repository.GetById(id);
                if (isExist != null)
                {
                    mapper.Map(dto, isExist);
                    isExist.DateUpdate = DateTime.Now;
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