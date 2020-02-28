using DCGP.TesteGol.Domain;
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
            return Ok(await _context.Airplanes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0) return BadRequest();

            var airplane = await _context.Airplanes.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (airplane == null) return NotFound();

            return Ok(await _context.Airplanes.Where(x => x.Id == id).FirstOrDefaultAsync());
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
