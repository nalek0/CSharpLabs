using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataDomenLevel.data
{
    [Table("Administrators")]
    public class AdministratorData
    {
        [Key]
        [Index]
        public int UserId { get; set; }
        [MaxLength(40)]
        public string FirstName { get; set; }
        [MaxLength(40)]
        public string LastName { get; set; }
        [MaxLength(16)]
        public string Nickname { get; set; }
        [MaxLength(16)]
        public string Password { get; set; }

        // Relationships:
        public ICollection<ReportData> Reports { get; set; }
    }
}
