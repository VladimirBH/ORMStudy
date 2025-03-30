using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMStudy.Models
{
    [PrimaryKey(nameof(Shifr))]
    [Table("Project")]
    public class Project
    {
        [Column("shifr")]
        public int Shifr { get; set; }

        [Column("project")]
        [MaxLength(50)]
        public string ProjectName { get; set; }

        [Column("topic")]
        [MaxLength(25)]
        public string Topic { get; set; }

        [Column("duration")]
        public int Duration { get; set; }

        [Column("dateStart")]
        public DateOnly DateStart { get; set; }

    }
}
