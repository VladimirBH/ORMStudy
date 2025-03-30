using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMStudy.Models
{
    [PrimaryKey(nameof(Id))]
    [Table("Team")]
    public class Team
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("team")]
        [MaxLength(50)]
        public string TeamName { get; set; }

        [Column("mentor")]
        public int MentorId { get; set; }

        [ForeignKey("MentorId")]
        public virtual Mentor Mentor { get; set; }
    }
}
