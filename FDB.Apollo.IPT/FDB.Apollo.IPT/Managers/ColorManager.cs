using AutoMapper;
using FDB.Apollo.IPT.Service.Models;
using FDB.Apollo.IPT.Service.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FDB.Apollo.IPT.Service.Managers
{
    public class ColorManager
    {
        private readonly postgresContext _context;
        private readonly IMapper _mapper;

        public ColorManager(postgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Color>> GetColors(DbContextLocale locale)
        {
            switch (locale)
            {
                case DbContextLocale.Working:
                    var qw = from aud in _context.IptColorAs
                             join wip in _context.IptColorWs on aud.Id equals wip.Id
                             join bc in _context.IptBasicColorWs on wip.BasicColorId equals bc.Id
                             select new { aud, wip, bc};

                    return (await qw.ToListAsync())
                        .Select(x =>
                        {
                            var r = _mapper.Map<Color>(x.wip);
                            r.Audit = _mapper.Map<PublishAudit>(x.aud);
                            r.Audit.SourceWIP = true;
                            r.BasicColor = _mapper.Map<BasicColor>(x.bc);
                            return r;
                        });
                case DbContextLocale.Published:
                    var qp = from aud in _context.IptColorAs
                             join pub in _context.IptColorPs on aud.Id equals pub.Id
                             join bc in _context.IptBasicColorPs on pub.BasicColorId equals bc.Id
                             select new { aud, pub, bc};

                    return (await qp.ToListAsync())
                        .Select(x =>
                        {
                            var r = _mapper.Map<Color>(x.pub);
                            r.Audit = _mapper.Map<PublishAudit>(x.aud);
                            r.Audit.SourceWIP = false;
                            r.BasicColor = _mapper.Map<BasicColor>(x.bc);
                            return r;
                        });
                default:
                    throw new ArgumentOutOfRangeException(nameof(locale));
            }
        }
    }
}
