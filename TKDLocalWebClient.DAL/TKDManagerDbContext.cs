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
            modelBuilder.Entity<PoomsaeType>().HasData(new PoomsaeType[]
            {
                new PoomsaeType{ ID = 1, Name = "Regular" },
                new PoomsaeType{ ID = 2, Name = "Freestyle" },
                new PoomsaeType{ ID = 3, Name = "FourDirections" },
            });
            modelBuilder.Entity<Category>().HasData(new Category[] 
            {
                new Category
                {
                    ID = 1, Name = @"Kadeti | <=5. geup | do 13 godina",
                    ShortName = @"KA-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 2, Name = @"Kadetkinje | <=5. geup | do 13 godina",
                    ShortName = @"KB-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 3, Name = @"Juniori | <=5. geup | 13 do 17 godina",
                    ShortName = @"JA-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 4, Name = @"Juniorke | <=5. geup | 13 do 17 godina",
                    ShortName = @"JB-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 5, Name = @"Seniori | <=5. geup | 18 do 30 godina",
                    ShortName = @"SA-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 6, Name = @"Seniorke | <=5. geup | 18 do 30 godina",
                    ShortName = @"SB-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 7, Name = @"Veterani | <=5. geup | od 30 godina",
                    ShortName = @"MA-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 8, Name = @"Veteranke | <=5. geup | od 30 godina",
                    ShortName = @"MB-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 9, Name = @"Invalidi M | Kognitivni invaliditet",
                    ShortName = @"PA-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 10, Name = @"Invalidi Ž | Kognitivni invaliditet",
                    ShortName = @"PB-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 11, Name = @"Parovi | <=5. geup",
                    ShortName = @"D-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                },
                new Category
                {
                    ID = 12, Name = @"Timovi | <=5. geup",
                    ShortName = @"T-1", IsFreestyle = false,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0,Poomsae32ID = 0
                },
                new Category
                {
                    ID = 13, Name = @"Freestyle M | <=5. geup",
                    ShortName = @"FA-1", IsFreestyle = true,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0,Poomsae32ID = 0
                },
                new Category
                {
                    ID = 14, Name = @"Freestyle Ž | <=5. geup",
                    ShortName = @"FB-1", IsFreestyle = true,
                    Poomsae11ID = 0, Poomsae12ID = 0, Poomsae21ID = 0, Poomsae22ID = 0, Poomsae31ID = 0, Poomsae32ID = 0
                }
            });
        }
    }
}