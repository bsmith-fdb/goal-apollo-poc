﻿using System;
using System.Collections.Generic;

namespace FDB.Apollo.IPT.Service.Models.EF
{
    public partial class IptColorP
    {
        public long Id { get; set; }
        public string Description { get; set; } = null!;
        public long BasicColorId { get; set; }
        public string Abbreviation { get; set; } = null!;
        public char DoNotUseInd { get; set; }

        public virtual IptBasicColorP BasicColor { get; set; } = null!;
        public virtual IptColorA Audit { get; set; } = null!;
    }
}
