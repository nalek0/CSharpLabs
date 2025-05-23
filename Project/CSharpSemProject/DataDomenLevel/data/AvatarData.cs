using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataDomenLevel.data
{
    [Table("Avatars")]
    public class AvatarData
    {
        [Key]
        [Index]
        public int AvatarId { get; set; }
        [MaxLength(256)]
        public string AvatarLink { get; set; }

        // Relationships:
        public virtual UserData User { get; set; }
    }
}
