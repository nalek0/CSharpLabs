using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataDomenLevel.data
{
    [Table("Videos")]
    public class VideoData
    {
        [Key]
        [Index]
        public int VideoId { get; set; }
        [MaxLength(1024)]
        public string Description { get; set; }

        // Relationships:
        public int UserId { get; set; }
        public UserData Author { get; set; }

        public ICollection<ReportData> Reports { get; set; }
    }
}
