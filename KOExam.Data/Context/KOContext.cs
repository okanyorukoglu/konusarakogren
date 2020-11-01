using KOExam.Core.Entities;
using KOExam.Data.Configs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KOExam.Data.Context
{
    public class KOContext : IdentityDbContext<User>
    {
        public KOContext(DbContextOptions<KOContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfig());
            

        }

        public DbSet<Question> Questions { get; set; }
 

        public DbSet<Test> Tests { get; set; }
        
        

        /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         {
             optionsBuilder.UseSqlite("Data Source = KOExam.db");
             base.OnConfiguring(optionsBuilder);
         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
         {
             modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = "1",
                     UserName = "okanyorukoglu",
                     PasswordHash = "okan123"
                 });
             base.OnModelCreating(modelBuilder);
         }
       */

    }
}
