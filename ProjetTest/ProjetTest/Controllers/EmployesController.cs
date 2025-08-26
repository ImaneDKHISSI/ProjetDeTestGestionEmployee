using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetTest.Dto;
using ProjetTest.Models;
using ProjetTest.Services.Interfaces;

namespace ProjetTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployesController : ControllerBase
    {
        private readonly IEmployeService employeService;
        public EmployesController(IEmployeService employeService)
        {
            this.employeService = employeService;
        }
        //[Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employe>>> GetAllEmployes()
        {
            var employe = await employeService.GetEmployes();
            return Ok(employe);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employe>> GetEmploye(int id)
        {
            var employe = await employeService.GetEmploye(id);
            return Ok(employe);
        }
        // [Route]
        [HttpGet("rechercheMarque")]
        public async Task<ActionResult<IEnumerable<Employe>>> RechercheEmploye(string searchText)
        {
            var employes = await employeService.Rechercher(searchText);
            return Ok(employes);
        }
        [HttpPost]
        public async Task<ActionResult<Employe>> AddEmploye([FromBody] EmployeDto employe)
        {
            var newEmploye = await employeService.AddEmploye(employe);
            return CreatedAtAction("GetEmploye", new { id = newEmploye.Id }, newEmploye);

        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmploye(int id)
        {
            var result = await employeService.DeleteEmploye(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmploye([FromBody] UpdateEmployeDto employe)
        {
            var updateEmploye = await employeService.UpdateEmploye(employe);
            if (updateEmploye == null)
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
