using AutoMapper;
using FDB.Apollo.IPT.Service.Models;
using FDB.Apollo.IPT.Service.Models.EF;
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

            return (await q.ToListAsync()).Select(c =>
            {
                Color color = _mapper.Map<Color>(c.Color);
                color.Audit.SourceWIP = color.BasicColor.Audit.SourceWIP = sourceWIP;
                return color;
            });
        }
    }
}
