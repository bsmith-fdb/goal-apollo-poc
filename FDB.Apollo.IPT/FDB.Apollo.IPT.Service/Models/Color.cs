namespace FDB.Apollo.IPT.Service.Models
{
    public class Color
    {
        public PublishAudit? Audit { get; set; }
        public long ID { get; set; }
        public string Description { get; set; } = null!;
        public long BasicColorID { get; set; }
        public string Abbreviation { get; set; } = null!;
        public bool DoNotUseInd { get; set; }
        public BasicColor? BasicColor { get; set; }
    }
}
