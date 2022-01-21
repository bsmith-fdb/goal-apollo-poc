using System;
using System.Collections.Generic;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptBasicColorC
    {
        public long Id { get; set; }
        public int RevNbr { get; set; }
        public string Description { get; set; } = null!;
        public string? Abbreviation { get; set; }
        public string? ShortAbbreviation { get; set; }
        public char DoNotUseInd { get; set; }
        public char ChangeType { get; set; }
        public long ChangeUserId { get; set; }
        public DateTime ChangeTimestamp { get; set; }
        public int ConceptRevNbr { get; set; }
        public int? DcrNbr { get; set; }
        public string? LegacyChangeUser { get; set; }
    }
}
