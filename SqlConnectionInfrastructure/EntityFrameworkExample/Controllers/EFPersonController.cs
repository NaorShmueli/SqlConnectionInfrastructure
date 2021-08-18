using EFDAL.DB.DTOs;
using EFDAL.DB.Entities;
using EntityFrameworkTemplate.Abstraction.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkExample.Controllers
{
    [Route("[Controller]/api")]
    public class EFPersonController : ControllerBase
    {
        private readonly ILogger<EFPersonController> _logger;
        private readonly IRepository<EFPerson> _repository;
        public EFPersonController(ILogger<EFPersonController> logger, IRepository<EFPerson> repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Upsert([FromBody] EFPersonDto person)
        {
            var efPerson = new EFPerson(person);
            var result = await _repository.Add(efPerson);
            return Ok(result);
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _repository.Get(id);
            return Ok(result);
        }

        [HttpGet("get/all")]
        public IActionResult GetAll()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(Guid id,[FromBody]EFPersonDto person)
        {
            var updatedEntity = new EFPerson(person);
            updatedEntity.Id = id;
            var result = await _repository.Update(updatedEntity);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var entity = await _repository.Get(id);
            var result = _repository.Delete(entity);
            return Ok(result);
        }
    }
}
