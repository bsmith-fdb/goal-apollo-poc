namespace FDB.Apollo.IPT.Service.Models
{
    public class PublishAudit
    {
        public long ID { get; set; }
        public long WIPStatusID { get; set; }
        public string WIPStatus => ((FDBWipStatus)WIPStatusID).DisplayText();
        public bool SourceWIP { get; set; }
        public DateTime CreateDate { get; set; }
        public long CreateUserID { get; set; }
        public string CreateUserName { get; set; } = null!;
        public DateTime CheckoutDate { get; set; }
        public long CheckoutUserID { get; set; }
        public string CheckoutUserName { get; set; } = null!;
        public DateTime LastModifyDate { get; set; }
        public long LastModifyUserID { get; set; }
        public string LastModifyUserName { get; set; } = null!;
        public DateTime PublishedDate { get; set; }
        public long PublishedUserID { get; set; }
        public string PublishedUserName { get; set; } = null!;
        public DateTime PlannedPublishDate { get; set; }
        public long PlannedPublishUserID { get; set; }
        public string PlannedPublishUserName { get; set; } = null!;
        public DateTime FirstDeliveredDate { get; set; }
        public DateTime LastDeliveredDate { get; set; }
    }
}
