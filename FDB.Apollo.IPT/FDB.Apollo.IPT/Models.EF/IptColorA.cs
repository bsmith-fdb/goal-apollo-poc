using System;
using System.Collections.Generic;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptColorA : AuditBase
    {
        public DateTime? PrevDeliveredDate { get; set; }

        public virtual IptColorP IptColorP { get; set; } = null!;
        public virtual IptColorW IptColorW { get; set; } = null!;
    }
}
