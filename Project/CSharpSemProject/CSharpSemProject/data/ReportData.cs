namespace CSharpSemProject
{
    public class ReportData
    {
        public long ReportId { get; set; }
        public long UserId { get; set; }
        public long VideoId { get; set;  }
        public string Description { get; set; }
        public ReportStatus Status { get; set; }
    }
}
