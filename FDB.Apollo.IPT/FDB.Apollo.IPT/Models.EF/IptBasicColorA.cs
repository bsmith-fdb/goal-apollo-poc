using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptBasicColorA : AuditBase
    {
        public DateTime? PrevDeliveredDate { get; set; }

        public virtual IptBasicColorP IptBasicColorP { get; set; } = null!;
        public virtual IptBasicColorW IptBasicColorW { get; set; } = null!;
    }
}
