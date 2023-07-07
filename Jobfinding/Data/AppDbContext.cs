using Jobfinding.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jobfinding.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
                 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<skills_findingjobs>().HasKey(sf => new
            {
                sf.FindjobsId,
                sf.SkillId
            });
            modelBuilder.Entity<skills_findingjobs>().HasOne(f =>f.Findjobs ).WithMany(sf => sf.skills_Findingjobs).HasForeignKey(f => f.FindjobsId);
            modelBuilder.Entity<skills_findingjobs>().HasOne(f => f.Skill).WithMany(sf => sf.skills_Findingjobs).HasForeignKey(f => f.SkillId);



            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Skill>Skills { get; set; }
        public DbSet<Findjobs> Findjobs { get; set; }
        public DbSet<skills_findingjobs> skills_Findingjobs { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<question_ans> question_anss { get; set; } 

        public DbSet<Apply> Apply { get; set; }

        public DbSet<Applyitem>Applyitems { get; set; }

        public DbSet<ApplyCartItem>ApplyCartItems { get; set; }

          


         

    }
} 
