using System;
using System.Collections.Generic;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptBasicColorA : IAudit
    {
        public long Id { get; set; }
        public long WipStatusId { get; set; }
        public DateTime AudCreateDate { get; set; }
        public long AudCreateUserId { get; set; }
        public DateTime? AudCheckoutDate { get; set; }
        public long? AudCheckoutUserId { get; set; }
        public DateTime AudLastModifyDate { get; set; }
        public long AudLastModifyUserId { get; set; }
        public DateTime? AudPublishDate { get; set; }
        public long? AudPublishUserId { get; set; }
        public DateTime? FirstDeliveredDate { get; set; }
        public DateTime? LastDeliveredDate { get; set; }
        public DateTime? PrevDeliveredDate { get; set; }

        public virtual IptBasicColorP IptBasicColorP { get; set; } = null!;
        public virtual IptBasicColorW IptBasicColorW { get; set; } = null!;
    }
}
