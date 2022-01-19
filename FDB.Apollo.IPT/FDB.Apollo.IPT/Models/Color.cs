namespace FDB.Apollo.IPT.Service.Models
{
    public class Color
    {
        public PublishAudit Audit { get; set; } = new PublishAudit();
        public int ID { get; set; }
        public string Description { get; set; } = string.Empty;
        public int BasicColorID { get; set; }
        public string Abbreviation { get; set; } = string.Empty;
        public bool DoNotUse { get; set; }
    }
}
