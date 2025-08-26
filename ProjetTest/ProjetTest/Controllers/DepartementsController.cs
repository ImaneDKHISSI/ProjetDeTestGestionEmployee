using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetTest.Dto;
using ProjetTest.Models;
using ProjetTest.Services.Implementations;
using ProjetTest.Services.Interfaces;

namespace ProjetTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartementsController : ControllerBase
    {
        private readonly IDepartementService departementService;
        public DepartementsController(IDepartementService departementService)
        {
            this.departementService = departementService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departement>>> GetAllDepartements()
        {
            var employe = await departementService.GetDepartements();
            return Ok(employe);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Departement>> GetDepartement(int id)
        {
            var departement = await departementService.GetDepartement(id);
            return Ok(departement);
        }
        // [Route]
        [HttpGet("rechercheDepartement")]
        public async Task<ActionResult<IEnumerable<Departement>>> RechercheDepartement(string searchText)
        {
            var departements = await departementService.Rechercher(searchText);
            return Ok(departements);
        }
        [HttpPost]
        public async Task<ActionResult<Departement>> AddDepartement([FromBody] DepartementDto departement)
        {
            var newDepartement = await departementService.AddDepartement(departement);
            return CreatedAtAction("GetDepartement", new { id = newDepartement.Id }, newDepartement);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartement(int id)
        {
            var result = await departementService.DeleteDepartement(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartement(int id, Departement departement)
        {
            var updateDepartement = await departementService.UpdateDepartement(id, departement);
            if (updateDepartement == null)
            {
                return BadRequest();
            }
            return NoContent();
        }

    }
}
