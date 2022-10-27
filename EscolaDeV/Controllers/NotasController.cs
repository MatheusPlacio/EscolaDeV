using EscolaDeV.Models;
using EscolaDeV.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        private readonly INotasService _notas;
        public NotasController(INotasService notas)
        {
            _notas = notas;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Notas notas)
        {
            return Ok(await _notas.Create(notas));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _notas.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _notas.GetById(id));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Notas notas, int id)
        {
            await _notas.Update(notas, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _notas.Delete(id);
            return NoContent();
        }
    }
}

