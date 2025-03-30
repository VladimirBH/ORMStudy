using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ORMStudy.Models
{
    [PrimaryKey(nameof(Id))]
    [Table("Mentor")]
    public class Mentor
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
    }
}
