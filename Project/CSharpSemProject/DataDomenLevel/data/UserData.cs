using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataDomenLevel.data
{
    [Table("Users")]
    public class UserData
    {
        [Key]
        [Index]
        public int UserId { get; set; }
        [MinLength(1)]
        [MaxLength(40)]
        public string FirstName { get; set; }
        [MinLength(1)]
        [MaxLength(40)]
        public string LastName { get; set; }
        [MinLength(1)]
        [MaxLength(16)]
        public string Nickname { get; set; }

        // Relationships:
        public AvatarData Avatar { get; set; }
        public ICollection<VideoData> Videos { get; set; }
    }
}
