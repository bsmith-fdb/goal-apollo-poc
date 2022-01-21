using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptBasicColorA : IAudit
    {
        public decimal Id { get; set; }
        public decimal WipStatusId { get; set; }
        public DateTime AudCreateDate { get; set; }
        public decimal AudCreateUserId { get; set; }
        public DateTime? AudCheckoutDate { get; set; }
        public decimal? AudCheckoutUserId { get; set; }
        public DateTime AudLastModifyDate { get; set; }
        public decimal AudLastModifyUserId { get; set; }
        public DateTime? AudPublishDate { get; set; }
        public decimal? AudPublishUserId { get; set; }
        public DateTime? FirstDeliveredDate { get; set; }
        public DateTime? LastDeliveredDate { get; set; }
        public DateTime? PrevDeliveredDate { get; set; }

        public virtual IptBasicColorP IptBasicColorP { get; set; } = null!;
        public virtual IptBasicColorW IptBasicColorW { get; set; } = null!;
    }
}
