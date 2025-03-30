using Microsoft.EntityFrameworkCore;

using ORMStudy.Models;

namespace ORMStudy.DataBase
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Work> Works { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(
                "Server=127.0.0.1;Port=3306;Database=DBProject;User=root;Password=123;"
            );
        }
    }
}
