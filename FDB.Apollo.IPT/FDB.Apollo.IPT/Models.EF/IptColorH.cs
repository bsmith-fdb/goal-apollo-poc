using System;
using System.Collections.Generic;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptColorH
    {
        public long Id { get; set; }
        public int RevNbr { get; set; }
        public long ChangeUserId { get; set; }
        public DateTime ChangeTimestamp { get; set; }
        public char ChangeType { get; set; }
        public int? DcrNbr { get; set; }
        public string? LegacyChangeUser { get; set; }
    }
}
