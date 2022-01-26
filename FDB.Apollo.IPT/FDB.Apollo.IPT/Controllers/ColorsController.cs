#nullable disable
using AutoMapper;
using FDB.Apollo.IPT.Service.Models;
using FDB.Apollo.IPT.Service.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FDB.Apollo.IPT.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    [Consumes("application/json")]
    public class ColorsController : ControllerBase
    {
        private readonly postgresContext _context;
        private readonly IMapper _mapper;

        public ColorsController(postgresContext context, IMapper mapper)
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
        public async Task<IActionResult> UpdateColor(long id, Color color)
        {
            var dtNow = DateTime.UtcNow;
            long changeUserID = 99999;
            char changeType = ChangeType.Change.GetChar();

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

                switch ((FDBWipStatus)audRec.WipStatusId)
                {
                    case FDBWipStatus.Protected:
                        return base.StatusCode((int)HttpStatusCode.NotModified);
                    default:
                        break;
                }

                audRec.AudLastModifyDate = dtNow;
                audRec.AudLastModifyUserId = changeUserID;

                _context.Entry(audRec).State = EntityState.Modified;

                var conceptRevNbr = await GetMaxConceptRevNbr(id) + 1;

                var histRec = new IptColorH
                {
                    Id = id,
                    RevNbr = conceptRevNbr,
                    ChangeUserId = changeUserID,
                    ChangeTimestamp = dtNow,
                    ChangeType = changeType
                };

                _context.Entry(histRec).State = EntityState.Added;

                var revNbr = await GetMaxRevNbr(id) + 1;

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

        // PUT: api/Colors/Publish/5
        [HttpPut("Publish/{id}", Name = nameof(PublishColor))]
        public async Task<IActionResult> PublishColor(long id)
        {
            var dtNow = DateTime.UtcNow;
            long changeUserID = 99999;
            char changeType = ChangeType.Publish.GetChar();

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var audRec = await _context.IptColorAs.FindAsync(id);

                if (audRec == null)
                {
                    return NotFound();
                }

                switch ((FDBWipStatus)audRec.WipStatusId)
                {
                    case FDBWipStatus.Published:
                    case FDBWipStatus.Protected:
                        return base.StatusCode((int)HttpStatusCode.NotModified);
                    default:
                        break;
                }

                audRec.WipStatusId = (long)FDBWipStatus.Published;
                audRec.AudCheckoutDate = null;
                audRec.AudCheckoutUserId = null;
                audRec.AudLastModifyDate = dtNow;
                audRec.AudLastModifyUserId = changeUserID;
                audRec.AudPublishDate = dtNow;
                audRec.AudPublishUserId = changeUserID;

                _context.Entry(audRec).State = EntityState.Modified;
                
                var wipRec = await _context.IptColorWs.FindAsync(id);

                var pubRec = await _context.IptColorPs.FindAsync(id);

                if (pubRec == null)
                {
                    pubRec = _mapper.Map<IptColorP>(wipRec);
                    _context.Entry(pubRec).State = EntityState.Added;
                }
                else
                {
                    _mapper.Map(wipRec, pubRec);
                    _context.Entry(pubRec).State = EntityState.Modified;
                }

                var conceptRevNbr = await GetMaxConceptRevNbr(id) + 1;

                var histRec = new IptColorH
                {
                    Id = id,
                    RevNbr = conceptRevNbr,
                    ChangeUserId = changeUserID,
                    ChangeTimestamp = dtNow,
                    ChangeType = changeType
                };

                _context.Entry(histRec).State = EntityState.Added;

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }

            return NoContent();
        }

        // PUT: api/Colors/Revert/5
        [HttpPut("Revert/{id}", Name = nameof(RevertColor))]
        public async Task<IActionResult> RevertColor(long id)
        {
            var dtNow = DateTime.UtcNow;
            long changeUserID = 99999;
            char changeType = ChangeType.Revert.GetChar();

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var audRec = await _context.IptColorAs.FindAsync(id);

                if (audRec == null)
                {
                    return NotFound();
                }

                if (audRec.AudPublishDate == null)
                {
                    return base.StatusCode((int)HttpStatusCode.NotModified);
                }

                audRec.WipStatusId = (long)FDBWipStatus.Published;
                audRec.AudCheckoutDate = null;
                audRec.AudCheckoutUserId = null;
                audRec.AudLastModifyDate = dtNow;
                audRec.AudLastModifyUserId = changeUserID;

                _context.Entry(audRec).State = EntityState.Modified;

                var wipRec = await _context.IptColorWs.FindAsync(id);

                var pubRec = await _context.IptColorPs.FindAsync(id);

                if (pubRec == null)
                {
                    return base.StatusCode((int)HttpStatusCode.NotModified);
                }

                _mapper.Map(pubRec, wipRec);
                _context.Entry(wipRec).State = EntityState.Modified;

                var conceptRevNbr = await GetMaxConceptRevNbr(id) + 1;

                var histRec = new IptColorH
                {
                    Id = id,
                    RevNbr = conceptRevNbr,
                    ChangeUserId = changeUserID,
                    ChangeTimestamp = dtNow,
                    ChangeType = changeType
                };

                _context.Entry(histRec).State = EntityState.Added;

                var revNbr = await GetMaxRevNbr(id) + 1;

                var changeRec = _mapper.Map<IptColorC>(wipRec);
                changeRec.ChangeType = changeType;
                changeRec.ChangeTimestamp = dtNow;
                changeRec.RevNbr = revNbr;
                changeRec.ChangeUserId = changeUserID;
                changeRec.ConceptRevNbr = conceptRevNbr;

                _context.Entry(changeRec).State = EntityState.Added;

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }

            return NoContent();
        }

        // POST: api/Colors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost(Name = nameof(CreateColor))]
        public async Task<ActionResult<Color>> CreateColor(Color color)
        {
            var dtNow = DateTime.UtcNow;
            long changeUserID = 99999;
            char changeType = ChangeType.Add.GetChar();
            int conceptRevNbr = 1;
            int revNbr = 1;

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var audRec = new IptColorA
                {
                    WipStatusId = (long)FDBWipStatus.CheckedOut,
                    AudCreateDate = dtNow,
                    AudCreateUserId = changeUserID,
                    AudCheckoutDate = dtNow,
                    AudCheckoutUserId = changeUserID,
                    AudLastModifyDate = dtNow,
                    AudLastModifyUserId = changeUserID,
                };

                _context.Entry(audRec).State = EntityState.Added;

                await _context.SaveChangesAsync();

                color.ID = audRec.Id;

                var histRec = new IptColorH
                {
                    Id = color.ID,
                    RevNbr = conceptRevNbr,
                    ChangeUserId = changeUserID,
                    ChangeTimestamp = dtNow,
                    ChangeType = changeType
                };

                _context.Entry(histRec).State = EntityState.Added;

                var changeRec = _mapper.Map<IptColorC>(color);
                changeRec.ChangeType = changeType;
                changeRec.ChangeTimestamp = dtNow;
                changeRec.RevNbr = revNbr;
                changeRec.ChangeUserId = changeUserID;
                changeRec.ConceptRevNbr = conceptRevNbr;
                _context.Entry(changeRec).State = EntityState.Added;

                var wipRec = _mapper.Map<IptColorW>(color);
                _context.Entry(wipRec).State = EntityState.Added;

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }

            return CreatedAtAction(nameof(GetColor), new { locale = DbContextLocale.Working, id = color.ID }, color);
        }

        // DELETE: api/Colors/5
        [HttpDelete("{id}", Name = nameof(DeleteColor))]
        public async Task<IActionResult> DeleteColor(long id)
        {
            var dtNow = DateTime.UtcNow;
            long changeUserID = 99999;
            char changeType = ChangeType.Delete.GetChar();

            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                var audRec = await _context.IptColorAs.FindAsync(id);

                if (audRec == null)
                {
                    return NotFound();
                }

                switch ((FDBWipStatus)audRec.WipStatusId)
                {
                    case FDBWipStatus.Protected:
                        return base.StatusCode((int)HttpStatusCode.NotModified);
                    default:
                        break;
                }

                var conceptRevNbr = await GetMaxConceptRevNbr(id) + 1;

                var histRec = new IptColorH
                {
                    Id = id,
                    RevNbr = conceptRevNbr,
                    ChangeUserId = changeUserID,
                    ChangeTimestamp = dtNow,
                    ChangeType = changeType
                };

                _context.Entry(histRec).State = EntityState.Added;

                var wipRec = await _context.IptColorWs.FindAsync(id);

                var revNbr = await GetMaxRevNbr(id) + 1;

                var changeRec = _mapper.Map<IptColorC>(wipRec);
                changeRec.ChangeType = changeType;
                changeRec.ChangeTimestamp = dtNow;
                changeRec.RevNbr = revNbr;
                changeRec.ChangeUserId = changeUserID;
                changeRec.ConceptRevNbr = conceptRevNbr;

                _context.Entry(changeRec).State = EntityState.Added;

                var pubRec = await _context.IptColorPs.FindAsync(id);

                if (pubRec != null)
                {
                    _context.IptColorPs.Remove(pubRec);
                }

                _context.IptColorWs.Remove(wipRec);
                _context.IptColorAs.Remove(audRec);

                await _context.SaveChangesAsync();

                await transaction.CommitAsync();
            }

            return NoContent();
        }

        private async Task<int> GetMaxRevNbr(long id)
        {
            return await _context.IptColorCs
                .Where(c => c.Id == id)
                .OrderByDescending(c => c.RevNbr)
                .Select(c => c.RevNbr)
                .FirstOrDefaultAsync();
        }

        private async Task<int> GetMaxConceptRevNbr(long id)
        {
            return await _context.IptColorHs
                .Where(h => h.Id == id)
                .OrderByDescending(h => h.RevNbr)
                .Select(h => h.RevNbr)
                .FirstOrDefaultAsync();
        }
    }
}
