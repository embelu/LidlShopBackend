using LidlShop.BL.Exceptions;
using LidlShop.BL.Interfaces;
using LidlShop.BL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LidlShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandeController : ControllerBase
    {
        private readonly ICommandeBL _commandeBL;

        public CommandeController(ICommandeBL commandeBL)
        {
            _commandeBL = commandeBL;
        }

        [HttpPost]
        public ActionResult<int> Post([FromBody] CommandeDTO commandeDTO)
        {
            try
            {
                return Ok(_commandeBL.Post(commandeDTO));
            }
            catch (CommandeException e)
            {

                return BadRequest(e.Message);
            }
        }


        [HttpGet]
        public ActionResult<List<CommandeDTO>> GetAll()
        {
            try
            {
                return Ok(_commandeBL.GetAll());
            }
            catch (NotFoundException e)
            {

                return NotFound(e.Message);
            }
        }


        // GET api/<CommandeController>/5
        [HttpGet("{id}")]
        public ActionResult<CommandeDTO> GetById(int id)
        {
            try
            {
                return Ok(_commandeBL.GetById(id));
            }
            catch (NotFoundException e)
            {

                return NotFound(e.Message);
            }
        }


        // DELETE api/<CommandeController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_commandeBL.Delete(id));
        }

        // PUT api/<CommandeController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] CommandeDTO commandeDTOUpdated)
        {
            if (id != commandeDTOUpdated.Id) return BadRequest();

            return _commandeBL.Put(commandeDTOUpdated);
        }
    }
}
