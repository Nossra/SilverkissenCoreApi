using Microsoft.EntityFrameworkCore;
using silverkissen.DbModels;
using System;
using System.Collections.Generic; 
using System.Linq;
using System.Threading.Tasks;

namespace silverkissen.Models
{
    public class SilverkissenContext : DbContext
    {
        public SilverkissenContext()
        {  }

        public SilverkissenContext(DbContextOptions<SilverkissenContext> options) : base(options)
        {  } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatLitterImages>().HasKey(t => new { t.CatLitterId, t.ImageId });
            modelBuilder.Entity<CatImages>().HasKey(t => new { t.CatId, t.ImageId });
            modelBuilder.Entity<CatFamily>().HasKey(t => new { t.CatId, t.CatLitterId });
        }

        public DbSet<Cat> Cats { get; set; } 
        public DbSet<CatLitter> CatLitters { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CatLitterImages> CatLitterImages { get; set; }
        public DbSet<CatImages> CatImages { get; set; }
        public DbSet<CatFamily> CatFamilies { get; set; }
    }
}
        