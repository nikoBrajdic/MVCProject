using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKDLocalWebClient.Model;

namespace TKDLocalWebClient.DAL
{
    public class TKDManagerDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<PoomsaeType> PoomsaeTypes { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Poomsae> Poomsaes { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected TKDManagerDbContext() { }
        public TKDManagerDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //
            // Cascade delete fix
            //
            modelBuilder.Entity<Category>().HasOne(c => c.Poomsae11).WithMany(p => p.Poomsae11s).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Category>().HasOne(c => c.Poomsae12).WithMany(p => p.Poomsae12s).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Category>().HasOne(c => c.Poomsae21).WithMany(p => p.Poomsae21s).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Category>().HasOne(c => c.Poomsae22).WithMany(p => p.Poomsae22s).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Category>().HasOne(c => c.Poomsae31).WithMany(p => p.Poomsae31s).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Category>().HasOne(c => c.Poomsae32).WithMany(p => p.Poomsae32s).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<PoomsaeType>().HasData(new PoomsaeType[]
            {
                new PoomsaeType { ID = 1, Name = "Regular" },
                new PoomsaeType { ID = 2, Name = "Freestyle" },
                new PoomsaeType { ID = 3, Name = "FourDirections" },
            });
            modelBuilder.Entity<Poomsae>().HasData(new Poomsae[] {
                new Poomsae { ID = 1, Name = "Taeguk Il Jang", ShortName = "Il-Jang", Ordinal = "1", PoomsaeTypeId = 1 },
                new Poomsae { ID = 2, Name = "Taeguk I Jang", ShortName = "I-Jang", Ordinal = "2", PoomsaeTypeId = 2 },
                new Poomsae { ID = 3, Name = "Taeguk Sam Jang", ShortName = "Sam-Jang", Ordinal = "3", PoomsaeTypeId = 3 },
                new Poomsae { ID = 4, Name = "Taeguk Sa Jang", ShortName = "Sa-Jang", Ordinal = "4", PoomsaeTypeId = 4 },
                new Poomsae { ID = 5, Name = "Taeguk O Jang", ShortName = "O-Jang", Ordinal = "5", PoomsaeTypeId = 5 },
                new Poomsae { ID = 6, Name = "Taeguk Yuk Jang", ShortName = "Yuk-Jang", Ordinal = "6", PoomsaeTypeId = 6 },
                new Poomsae { ID = 7, Name = "Taeguk Chil Jang", ShortName = "Chil-Jang", Ordinal = "7", PoomsaeTypeId = 7 },
                new Poomsae { ID = 8, Name = "Taeguk Pal Jang", ShortName = "Pal-Jang", Ordinal = "8", PoomsaeTypeId = 8 },
                new Poomsae { ID = 9, Name = "Koryo", ShortName = "Koryo", Ordinal = "9", PoomsaeTypeId = 9 },
                new Poomsae { ID = 10, Name = "Keumgang", ShortName = "Keumgang", Ordinal = "10", PoomsaeTypeId = 10 },
                new Poomsae { ID = 11, Name = "Taebaek", ShortName = "Taebaek", Ordinal = "11", PoomsaeTypeId = 11 },
                new Poomsae { ID = 12, Name = "Pyongwon", ShortName = "Pyongwon", Ordinal = "12", PoomsaeTypeId = 12 },
                new Poomsae { ID = 13, Name = "Sipjin", ShortName = "Sipjin", Ordinal = "13", PoomsaeTypeId = 13 },
                new Poomsae { ID = 14, Name = "Jitae", ShortName = "Jitae", Ordinal = "14", PoomsaeTypeId = 14 },
                new Poomsae { ID = 15, Name = "Chonkwon", ShortName = "Chonkwon", Ordinal = "15", PoomsaeTypeId = 15 },
                new Poomsae { ID = 16, Name = "Hansoo", ShortName = "Hansoo", Ordinal = "16", PoomsaeTypeId = 16 },
                new Poomsae { ID = 17, Name = "Ilyo", ShortName = "Ilyo", Ordinal = "17", PoomsaeTypeId = 17 },
            });
            modelBuilder.Entity<Category>().HasData(new Category[] 
            {
                new Category { ID = 1, Name = @"Kadeti | <=5. geup | do 13 godina", ShortName = @"KA-1", IsFreestyle = false },
                new Category { ID = 2, Name = @"Kadetkinje | <=5. geup | do 13 godina", ShortName = @"KB-1", IsFreestyle = false },
                new Category { ID = 3, Name = @"Juniori | <=5. geup | 13 do 17 godina", ShortName = @"JA-1", IsFreestyle = false },
                new Category { ID = 4, Name = @"Juniorke | <=5. geup | 13 do 17 godina", ShortName = @"JB-1", IsFreestyle = false },
                new Category { ID = 5, Name = @"Seniori | <=5. geup | 18 do 30 godina", ShortName = @"SA-1", IsFreestyle = false },
                new Category { ID = 6, Name = @"Seniorke | <=5. geup | 18 do 30 godina", ShortName = @"SB-1", IsFreestyle = false },
                new Category { ID = 7, Name = @"Veterani | <=5. geup | od 30 godina", ShortName = @"MA-1", IsFreestyle = false },
                new Category { ID = 8, Name = @"Veteranke | <=5. geup | od 30 godina", ShortName = @"MB-1", IsFreestyle = false },
                new Category { ID = 9, Name = @"Invalidi M | Kognitivni invaliditet", ShortName = @"PA-1", IsFreestyle = false },
                new Category { ID = 10, Name = @"Invalidi Ž | Kognitivni invaliditet", ShortName = @"PB-1", IsFreestyle = false },
                new Category { ID = 11, Name = @"Parovi | <=5. geup", ShortName = @"D-1", IsFreestyle = false },
                new Category { ID = 12, Name = @"Timovi | <=5. geup", ShortName = @"T-1", IsFreestyle = false },
                new Category { ID = 13, Name = @"Freestyle M | <=5. geup", ShortName = @"FA-1", IsFreestyle = true },
                new Category { ID = 14, Name = @"Freestyle Ž | <=5. geup", ShortName = @"FB-1", IsFreestyle = true }
            });
            modelBuilder.Entity<Team>().HasData(new Team { ID = 1, Name = "TKD Klub Jastreb" });
            modelBuilder.Entity<Contestant>().HasData(new Contestant { ID = 1, Name = "Niko", Surname = "Brajdić", TeamId = 1, CategoryId = 5 });
        }
    }
}