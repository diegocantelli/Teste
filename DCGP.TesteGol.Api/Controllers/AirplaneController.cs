using DCGP.TesteGol.Domain;
using DCGP.TesteGol.Domain.DTOs;
using DCGP.TesteGol.Infra.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DCGP.TesteGol.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AirplaneController: ControllerBase
    {
        private readonly DataContext _context;

        public AirplaneController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEditAirplane([FromBody]Airplane airplane)
        {
            if (!ModelState.IsValid) return BadRequest();

            if (airplane.Id == 0)
                await _context.AddAsync(airplane);
            else
                _context.Update(airplane);

            await _context.SaveChangesAsync();

            return Ok(airplane);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.Airplanes
                .OrderBy(x=> x.Modelo)
                .Select(x => new AirplaneDTO(x.Id, x.Modelo, x.QtdPassageiros, x.DataCriacaoRegistro))
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();

            var airplane = await _context.Airplanes.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (airplane == null) return NotFound();

            return Ok(airplane);
        }

        [HttpGet("modelo/{modelo}")]
        public async Task<IActionResult> GetByModelo(string modelo)
        {
            if (string.IsNullOrEmpty(modelo)) return BadRequest();

            var modeloDB = await _context.Airplanes.Where(x => x.Modelo == modelo)
                .OrderBy(x=>x.Modelo)
                .ToListAsync();

            if (modeloDB == null) return NotFound();

            return Ok(modeloDB);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id < 0) return BadRequest();

            var airplane = _context.Airplanes.Where(x => x.Id == id).FirstOrDefault();

            if (airplane == null) return NotFound();

            _context.Airplanes.Remove(airplane);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
