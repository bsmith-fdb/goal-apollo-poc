namespace FDB.Apollo.IPT.Service.Models
{
    public class Color
    {
        public PublishAudit Audit { get; set; } = null!;
        public int ID { get; set; }
        public string Description { get; set; } = null!;
        public int BasicColorID { get; set; }
        public string Abbreviation { get; set; } = null!;
        public bool DoNotUse { get; set; }
        public BasicColor BasicColor { get; set; } = null!;
    }
}
