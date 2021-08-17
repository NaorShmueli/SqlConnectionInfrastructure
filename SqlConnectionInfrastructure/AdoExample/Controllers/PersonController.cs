using DAL.DTOs;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdoExample.Controllers
{
    [Route("[Controller]/api")]
    public class PersonController : ControllerBase
    {
        private readonly IDataAccessConnector _connector;
        private readonly ILogger<PersonController> _logger;
        public PersonController(ILogger<PersonController> logger, IDataAccessConnector dataAccessConnector)
        {
            _connector = dataAccessConnector;
            _logger = logger;
        }

        [HttpPost("upsert")]
        public async Task<IActionResult> Upsert(IList<PersonDto> persons)
        {
            var rowEffected = await _connector.UpsertPersons(persons);
            return Ok(rowEffected);
        }
        [HttpGet("get")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _connector.GetPerson(id);
            return Ok(result);
        }

        [HttpGet("get/all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _connector.GetPersons();
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _connector.DeletePerson(id);
            return Ok(result);
        }
    }
}
