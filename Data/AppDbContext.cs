using ATS_Friendly_CV_Generator.Models;
using Microsoft.EntityFrameworkCore;

namespace ATS_Friendly_CV_Generator.Data
{
    //DbContext is the database connection manager
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
        {

        }

        //DbSet<InfoItem> represents Info Item table in our database
        public DbSet<InfoItem> InfoItems { get; set; }

        public DbSet<SkillsItem> SkillsItems { get; set; }

        public DbSet<EducationItem> EducationItems { get; set; }

        public DbSet<ExperienceItem> ExperienceItems { get; set; }
    }
}
