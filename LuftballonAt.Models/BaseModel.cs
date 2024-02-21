
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LuftballonAt.Models
{
    public class BaseModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; } = null;

        [Timestamp]
        [ConcurrencyCheck]
        public byte[] TimeStamp { get; set; } = null!;
    }
}
