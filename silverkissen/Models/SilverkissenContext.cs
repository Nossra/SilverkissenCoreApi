using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<CatLitter_Image>().HasKey(t => new { t.CatLitterId, t.ImageId });
            modelBuilder.Entity<Cat_Image>().HasKey(t => new { t.CatId, t.ImageId });
            modelBuilder.Entity<CatLitter_Parent>().HasKey(t => new { t.CatId, t.CatLitterId });

            modelBuilder.Entity<Cat>().HasOne(c => c.CatLitter).WithMany(cl => cl.Kittens).OnDelete(DeleteBehavior.SetNull);  
    }

        public DbSet<Cat> Cats { get; set; } 
        public DbSet<CatLitter> CatLitters { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CatLitter_Image> CatLitter_Image { get; set; }
        public DbSet<Cat_Image> Cat_Image { get; set; }
        public DbSet<CatLitter_Parent> CatLitter_Parent { get; set; } 
    }
}
        