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
    }
}
