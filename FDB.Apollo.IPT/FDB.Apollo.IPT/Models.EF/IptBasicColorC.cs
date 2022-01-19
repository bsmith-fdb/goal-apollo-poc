using System;
using System.Collections.Generic;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptBasicColorC
    {
        public decimal Id { get; set; }
        public decimal RevNbr { get; set; }
        public string Description { get; set; } = null!;
        public string? Abbreviation { get; set; }
        public string? ShortAbbreviation { get; set; }
        public char DoNotUseInd { get; set; }
        public char ChangeType { get; set; }
        public decimal ChangeUserId { get; set; }
        public DateTime ChangeTimestamp { get; set; }
        public decimal ConceptRevNbr { get; set; }
        public decimal? DcrNbr { get; set; }
        public string? LegacyChangeUser { get; set; }
    }
}
