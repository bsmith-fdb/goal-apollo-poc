using System;
using System.Collections.Generic;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptBasicColorW
    {
        public IptBasicColorW()
        {
            IptColorWs = new HashSet<IptColorW>();
        }

        public decimal Id { get; set; }
        public string Description { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
        public string ShortAbbreviation { get; set; } = null!;
        public char DoNotUseInd { get; set; }

        public virtual IptBasicColorA IdNavigation { get; set; } = null!;
        public virtual ICollection<IptColorW> IptColorWs { get; set; }
    }
}
