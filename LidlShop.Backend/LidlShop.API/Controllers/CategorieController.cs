using LidlShop.BL.Exceptions;
using LidlShop.BL.Interfaces;
using LidlShop.BL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LidlShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieBL _categorieBL;
        public CategorieController(ICategorieBL categorieBL)
        {
            _categorieBL = categorieBL;
        }

        // POST api/<CategorieController>
        [HttpPost]
        public ActionResult<int> Post([FromBody] CategorieDTO categorieDTO)
        {
            return Ok(_categorieBL.Post(categorieDTO));
        }


        // GET: api/<CategorieController>
        [HttpGet]
        public ActionResult<List<CategorieDTO>> GetAll()
        {
            try
            {
                return Ok(_categorieBL.GetAll());
            }
            catch (NotFoundException e)
            {

                return NotFound(e.Message);
            }
            
        }


        // GET api/<CategorieController>/5
        [HttpGet("{id}")]
        public ActionResult<CategorieDTO> GetById(int id)
        {
            try
            {
                return Ok(_categorieBL.GetById(id));
            }
            catch (NotFoundException e)
            {

                return NotFound(e.Message);
            }
            
        }


        // PUT api/<CategorieController>/5
        [HttpPut("{id}")]
        public ActionResult<int> Put(int id, [FromBody] CategorieDTO categorieDTO)
        {
            if (id != categorieDTO.Id) return BadRequest();

            return _categorieBL.Put(categorieDTO);
        }


        // DELETE api/<CategorieController>/5
        [HttpDelete("{id}")]
        public ActionResult<int> Delete(int id)
        {
            return Ok(_categorieBL.Delete(id));
        }
    }
}
