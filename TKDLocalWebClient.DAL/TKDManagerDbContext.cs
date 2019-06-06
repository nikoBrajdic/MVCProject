using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TKDLocalWebClient.Model;

namespace TKDLocalWebClient.DAL
{
    public class TKDManagerDbContext : DbContext
    {
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Poomsae> Poomsaes { get; set; }
        public DbSet<Score> Scores { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected TKDManagerDbContext() { }
        public TKDManagerDbContext(DbContextOptions options) : base(options) { }
    }
}