namespace FDB.Apollo.IPT.Service.Models
{
    public class PublishAudit
    {
        public int ID { get; set; }
        public int WIPStatusID { get; set; }
        public string WIPStatus { get; set; } = string.Empty;
        public bool SourceWIP { get; set; }
        public bool IsDelivered => FirstDeliveredDate != DateTime.MinValue;
        public DateTime CreateDate { get; set; }
        public int CreateUserID { get; set; }
        public string CreateUserName { get; set; } = string.Empty;
        public DateTime CheckoutDate { get; set; }
        public int CheckoutUserID { get; set; }
        public string CheckoutUserName { get; set; }= string.Empty;
        public DateTime LastModifyDate { get; set; }
        public int LastModifyUserID { get; set; }
        public string LastModifyUserName { get; set; } = string.Empty;
        public DateTime PublishedDate { get; set; }
        public int PublishedUserID { get; set; }
        public string PublishedUserName { get; set; } = string.Empty;
        public DateTime PlannedPublishDate { get; set; }
        public int PlannedPublishUserID { get; set; }
        public string PlannedPublishUserName { get; set; } = string.Empty;
        public DateTime FirstDeliveredDate { get; set; }
        public DateTime LastDeliveredDate { get; set; }
    }
}
