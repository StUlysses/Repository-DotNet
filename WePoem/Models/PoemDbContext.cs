using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class PoemDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("server=DESKTOP-O09BJ4P;uid=sa;pwd=123456;database=POEM");
        }

        public DbSet<Poem> Poem { get; set; }
        public DbSet<PoemCollection> PoemCollection { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<PoemFollow> PoemFollow { get; set; }
        public DbSet<UserFollow> UserFollow { get; set; }
        public DbSet<PLog> PLog { get; set; }
    }
}
