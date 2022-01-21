namespace FDB.Apollo.IPT.Service.Models
{
    public class BasicColor
    {
        public PublishAudit? Audit { get; set; }
        public int ID { get; set; }
        public string Description { get; set; } = null!;
        public string Abbreviation { get; set; } = null!;
        public string ShortAbbreviation { get; set; } = null!;
        public bool DoNotUseInd { get; set; }
    }
}
