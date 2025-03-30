using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORMStudy.Models
{
    [PrimaryKey(nameof(Id))]
    [Table("Work")]
    public class Work
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("takt")]
        public int Takt { get; set; }

        [Column("result")]
        [MaxLength(100)]
        public string Result { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("project_shifr")]
        public int ProjectShifr { get; set; }

        [ForeignKey("StudentId")]
        public virtual Students Student { get; set; }

        [ForeignKey("ProjectShifr")]
        public virtual Project Project { get; set; }
    }
}


