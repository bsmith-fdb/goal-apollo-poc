#nullable disable
using AutoMapper;
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
        private readonly IMapper _mapper;

        public ColorController(postgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Colors
        [HttpGet(Name = nameof(GetColors))]
        public async Task<ActionResult<IEnumerable<Color>>> GetColors(DbContextLocale locale)
        {
            IQueryable<dynamic> q;
            bool sourceWIP;

            switch (locale)
            {
                case DbContextLocale.Working:
                    sourceWIP = true;
                    q = from color in _context.IptColorWs
                        select new
                        {
                            Color = color,
                            ColorAudit = color.Audit,
                            BasicColor = color.BasicColor,
                            BasicColorAudit = color.BasicColor.Audit
                        };
                    break;
                case DbContextLocale.Published:
                    sourceWIP = false;
                    q = from color in _context.IptColorPs
                        select new
                        {
                            Color = color,
                            ColorAudit = color.Audit,
                            BasicColor = color.BasicColor,
                            BasicColorAudit = color.BasicColor.Audit
                        };
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(locale));
            }

            var qResult = await q.ToListAsync();

            var cResult = qResult.Select(c =>
            {
                Color color = _mapper.Map<Color>(c.Color);
                color.Audit.SourceWIP = color.BasicColor.Audit.SourceWIP = sourceWIP;
                return color;
            });

            return Ok(cResult);
        }

        // GET: api/Colors/5
        [HttpGet("{id}", Name = nameof(GetColor))]
        public async Task<ActionResult<Color>> GetColor(DbContextLocale locale, int id)
        {
            IQueryable<dynamic> q;
            bool sourceWIP;

            switch (locale)
            {
                case DbContextLocale.Working:
                    sourceWIP = true;
                    q = from c in _context.IptColorWs
                        where c.Id == id
                        select new
                        {
                            Color = c,
                            ColorAudit = c.Audit,
                            BasicColor = c.BasicColor,
                            BasicColorAudit = c.BasicColor.Audit
                        };
                    break;
                case DbContextLocale.Published:
                    sourceWIP = false;
                    q = from c in _context.IptColorPs
                        where c.Id == id
                        select new
                        {
                            Color = c,
                            ColorAudit = c.Audit,
                            BasicColor = c.BasicColor,
                            BasicColorAudit = c.BasicColor.Audit
                        };
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(locale));
            }

            var result = await q.FirstOrDefaultAsync();

            if (result == null)
            {
                return NotFound();
            }

            Color color = _mapper.Map<Color>(result.Color);
            color.Audit.SourceWIP = color.BasicColor.Audit.SourceWIP = sourceWIP;

            return Ok(color);
        }

        // PUT: api/Colors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}", Name = nameof(UpdateColor))]
        public async Task<IActionResult> UpdateColor(decimal id, Color color)
        {
            var dtNow = DateTime.UtcNow;
            decimal changeUserID = 99999;
            char changeType = 'C';

            if (id != color.ID)
            {
                return BadRequest();
            }

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var audRec = await _context.IptColorAs.FindAsync(id);

                if (audRec == null)
                {
                    return NotFound();
                }

                audRec.AudCheckoutDate = dtNow;
                audRec.AudCheckoutUserId = changeUserID;
                audRec.AudLastModifyDate = dtNow;
                audRec.AudLastModifyUserId = changeUserID;

                _context.Entry(audRec).State = EntityState.Modified;

                decimal conceptRevNbr = await GetMaxConceptRevNbr(id) + 1;

                var histRec = new IptColorH
                {
                    Id = id,
                    RevNbr = conceptRevNbr,
                    ChangeUserId = changeUserID,
                    ChangeTimestamp = dtNow,
                    ChangeType = changeType
                };

                _context.Entry(histRec).State = EntityState.Added;

                decimal revNbr = await GetMaxRevNbr(id) + 1;

                var changeRec = _mapper.Map<IptColorC>(color);
                changeRec.ChangeType = changeType;
                changeRec.ChangeTimestamp = dtNow;
                changeRec.RevNbr = revNbr;
                changeRec.ChangeUserId = changeUserID;
                changeRec.ConceptRevNbr = conceptRevNbr;
                _context.Entry(changeRec).State = EntityState.Added;

                var wipRec = _mapper.Map<IptColorW>(color);
                _context.Entry(wipRec).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
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

        //private async Task<bool> ColorExists(int id)
        //{
        //    return await _context.IptColorAs.AnyAsync(e => e.Id == id);
        //}

        private async Task<decimal> GetMaxRevNbr(decimal id)
        {
            return await _context.IptColorCs
                .Where(c => c.Id == id)
                .OrderByDescending(c => c.RevNbr)
                .Select(c => c.RevNbr)
                .FirstOrDefaultAsync();
        }

        private async Task<decimal> GetMaxConceptRevNbr(decimal id)
        {
            return await _context.IptColorHs
                .Where(h => h.Id == id)
                .OrderByDescending(h => h.RevNbr)
                .Select(h => h.RevNbr)
                .FirstOrDefaultAsync();
        }
    }
}
