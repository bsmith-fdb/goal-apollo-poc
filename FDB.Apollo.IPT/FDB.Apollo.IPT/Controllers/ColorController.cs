using AutoMapper;
using FDB.Apollo.IPT.Service.Managers;
using FDB.Apollo.IPT.Service.Models;
using FDB.Apollo.IPT.Service.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FDB.Apollo.IPT.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ColorController : ControllerBase
    {
        private readonly postgresContext _context;
        private readonly ColorManager _manager;
        private readonly IMapper _mapper;

        public ColorController(postgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _manager = new ColorManager(context, mapper);
        }

        // GET: api/Colors
        [HttpGet(Name = nameof(GetColors))]
        public async Task<IEnumerable<Color>> GetColors(DbContextLocale locale)
        {
            return await _manager.GetColors(locale);
        }

        // GET: api/Colors/5
        [HttpGet("{id}", Name = nameof(GetColor))]
        public async Task<ActionResult<Color>> GetColor(int id)
        {
            var color = await _context.Color.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return color;
        }

        // PUT: api/Colors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutColor(int id, Color color)
        {
            if (id != color.ID)
            {
                return BadRequest();
            }

            _context.Entry(color).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Color>> PostColor(Color color)
        {
            _context.Color.Add(color);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetColor", new { id = color.ID }, color);
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor(int id)
        {
            var color = await _context.Color.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.Color.Remove(color);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ColorExists(int id)
        {
            return _context.Color.Any(e => e.ID == id);
        }
    }
}
