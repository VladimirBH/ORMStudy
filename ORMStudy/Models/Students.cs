using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMStudy.Models
{
    [PrimaryKey(nameof(Id))]
    [Table("Students")]
    public class Students
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("lastName")]
        [MaxLength(25)]
        public string LastName { get; set; }

        [Column("name")]
        [MaxLength(25)]
        public string Name { get; set; }

        [Column("gender")]
        [MaxLength(2)]
        public string Gender { get; set; }

        [Column("team")]
        public int TeamId { get; set; }

        [ForeignKey("TeamId")]
        public virtual Team Team { get; set; }
    }
}
