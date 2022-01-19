using System;
using System.Collections.Generic;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptColorA
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
    }
}
