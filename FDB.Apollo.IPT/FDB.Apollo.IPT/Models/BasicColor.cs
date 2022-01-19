namespace FDB.Apollo.IPT.Service.Models
{
    public class BasicColor
    {
        public PublishAudit Audit { get; set; } = new PublishAudit();
        public int ID { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Abbreviation { get; set; } = string.Empty;
        public string ShortAbbreviation { get; set; } = string.Empty;
        public bool DoNotUse { get; set; }
    }
}
