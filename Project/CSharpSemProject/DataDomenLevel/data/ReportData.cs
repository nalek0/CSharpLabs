using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataDomenLevel.data
{
    public class ReportData
    {
        [Key]
        [Index]
        public int ReportId { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }
        public ReportStatus Status { get; set; }

        // Relationships:
        public int VideoId { get; set; }
        public VideoData Video { get; set; }

        public ICollection<AdministratorData> Administrators { get; set; }
    }
}
